using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoreScheduler.Client.Desktop.Utilities
{
    public partial class ImageListBuilder
    {
        public static ImageListBuilder Create()
        {
            return new ImageListBuilder(null, Size.Small);
        }

        public static ImageListBuilder Create(string dll)
        {
            return new ImageListBuilder(dll, Size.Small);
        }

        public static ImageListBuilder Create(string dll, bool size)
        {
            return new ImageListBuilder(dll, size ? Size.Large : Size.Small);
        }

        public static ImageListBuilder Create(string dll, Size size)
        {
            return new ImageListBuilder(dll, size);
        }

        #region Constructors

        private ImageListBuilder(string defaultDll, Size defaultSize)
        {
            _list = new ImageList();
            _defaultDll = defaultDll;
            SetColorDepth(ColorDepth.Depth32Bit);


            if (defaultSize == Size.Large)
            {
                SetSize(32, 32);
            }

            _defaultSize = defaultSize;
        }

        #endregion

        #region Private Fields

        private readonly ImageList _list;
        private readonly string _defaultDll;
        private readonly Size _defaultSize;

        #endregion

        #region Public Properties

        public bool ErrorState { get; private set; }

        #endregion

        #region Builder Functions

        public ImageListBuilder WithDllIcon(string name, int dllIndex, string dllPath, Size size, out int index)
        {
            var icon = Extract(dllPath, dllIndex, size);
            if (icon != null)
            {
                ErrorState = false;
                if (name == null)
                    _list.Images.Add(icon.ToBitmap());
                else
                    _list.Images.Add(name, icon.ToBitmap());
                index = _list.Images.Count - 1;
            }
            else
            {
                index = -1;
                ErrorState = true;
            }
            return this;
        }

        public ImageListBuilder WithExtensionIcon(string ext, out int index)
        {
            var icon = GetFileIcon(ext, _defaultSize);
            if (icon != null)
            {
                ErrorState = false;
                _list.Images.Add(icon.ToBitmap());
                index = _list.Images.Count - 1;
            }
            else
            {
                ErrorState = true;
                index = -1;
            }
            return this;
        }

        public ImageListBuilder WithStockIcon(SHStockIconId stockIcon, Size size, out int index)
        {
            var img = ExtractBitmap(stockIcon, size);
            if (img != null)
                _list.Images.Add(img);
            index = _list.Images.Count - 1;
            return this;
        }

        public ImageListBuilder WithResource(string fileName, out int index)
        {
            _list.Images.Add(Image.FromFile("Resources/" + fileName));
            index = _list.Images.Count - 1;
            return this;
        }

        public ImageListBuilder WithImage(Image img, out int index)
        {
            _list.Images.Add(img);
            index = _list.Images.Count - 1;
            return this;
        }

        public ImageListBuilder WithIcon(Icon ico, out int index)
        {
            _list.Images.Add(ico.ToBitmap());
            index = _list.Images.Count - 1;
            return this;
        }

        public ImageListBuilder SetSize(int w, int h)
        {
            _list.ImageSize = new System.Drawing.Size(w, h);
            return this;
        }

        public ImageListBuilder SetColorDepth(ColorDepth depth)
        {
            _list.ColorDepth = depth;
            return this;
        }

        #endregion

        public ImageList Build()
        {
            return _list;
        }

        #region Utility Methods

        public Image ExtractBitmap(string ext, Size size)
        {
            var icon = GetFileIcon(ext, size);

            return icon == null ? null : icon.ToBitmap();
        }

        public Image ExtractBitmap(int dllIndex, Size size)
        {
            var icon = Extract(_defaultDll, dllIndex, size);

            return icon == null ? null : icon.ToBitmap();
        }

        public Image ExtractBitmap(SHStockIconId stockIcon, Size size)
        {
            SHStockIconInfo sii = new SHStockIconInfo();
            sii.cbSize = (UInt32) Marshal.SizeOf(typeof(SHStockIconInfo));

            SHGSI flags = SHGSI.Icon;

            if (size == Size.Small)
                flags |= SHGSI.SmallIcon;

            try
            {
                Marshal.ThrowExceptionForHR(SHGetStockIconInfo(stockIcon, flags, ref sii));
            }
            catch (Exception)
            {
                ErrorState = true;
                return null;
            }

            var bitmap = ((Icon)Icon.FromHandle(sii.hIcon).Clone()).ToBitmap();
            DestroyIcon(sii.hIcon);
            return bitmap;
        }

        public static Icon Extract(string file, int number, Size size)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                return Icon.FromHandle(size == Size.Large ? large : small);
            }
            catch
            {
                return null;
            }

        }

        public static Icon GetFileIcon(string name, Size size)
        {
            var shfi = new SHFileInfo();
            var flags = (uint)(SHGSI.Icon | SHGSI.UseFileAttributes);

            if (size == Size.Large)
                flags += (uint)SHGSI.LargeIcon;
            else
                flags += (uint)SHGSI.SmallIcon;


            if (size > Size.Large)
            {
                flags |= (uint) SHGSI.SysIconIndex;

            }

            SHGetFileInfo(name, (uint)SHGSI.FileAttributeNormal, ref shfi, (uint)Marshal.SizeOf(shfi), flags);
            
            IntPtr hIcon = IntPtr.Zero;
            if (size > Size.Large)
            {
                Guid iidImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");

                IImageList iml;
                int icoSize = 0;
                if (size == Size.XLarge)
                    icoSize = 0x2;
                else if (size == Size.Jumbo)
                    icoSize = 0x4;

                var hres = SHGetImageList(icoSize, ref iidImageList, out iml);

                int ILD_TRANSPARENT = 1;
                hres = iml.GetIcon(shfi.iIcon, ILD_TRANSPARENT, ref hIcon);
            }
            else
            {
                hIcon = shfi.hIcon;
            }


            Icon icon = (Icon)Icon.FromHandle(hIcon).Clone();
            DestroyIcon(shfi.hIcon);
            return icon;
        }

        #endregion

        #region External

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        [DllImport("Shell32.dll", SetLastError = false)]
        public static extern Int32 SHGetStockIconInfo(SHStockIconId siid, SHGSI uFlags, ref SHStockIconInfo psii);

        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFileInfo psfi, uint cbFileInfo, uint uFlags);

        [DllImport("shell32.dll", EntryPoint = "#727")]
        public static extern int SHGetImageList(int iImageList, ref Guid riid, out IImageList ppv);
        #endregion

        public enum Size
        {
            Small,
            Large,
            XLarge,
            Jumbo
        }
    }
}
