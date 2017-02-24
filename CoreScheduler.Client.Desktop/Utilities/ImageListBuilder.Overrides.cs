using System.Drawing;

namespace CoreScheduler.Client.Desktop.Utilities
{
    // This file contains the overrides for methods in the main class
    public partial class ImageListBuilder
    {
        #region WithDllIcon
        public ImageListBuilder WithDllIcon(string name, int dllIndex, Size size, out int index)
        {
            return WithDllIcon(name, dllIndex, _defaultDll, size, out index);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex, string dllPath, out int index)
        {
            return WithDllIcon(name, dllIndex, dllPath, _defaultSize, out index);
        }

        public ImageListBuilder WithDllIcon(int dllIndex, string dllPath, out int index)
        {
            return WithDllIcon(null, dllIndex, dllPath, _defaultSize, out index);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex, out int index)
        {
            return WithDllIcon(name, dllIndex, _defaultDll, _defaultSize, out index);
        }

        public ImageListBuilder WithDllIcon(int dllIndex, out int index)
        {
            return WithDllIcon(null, dllIndex, _defaultDll, _defaultSize, out index);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex, Size size)
        {
            return WithDllIcon(name, dllIndex, _defaultDll, size);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex, string dllPath)
        {
            return WithDllIcon(name, dllIndex, dllPath, _defaultSize);
        }

        public ImageListBuilder WithDllIcon(int dllIndex, string dllPath)
        {
            return WithDllIcon(null, dllIndex, dllPath, _defaultSize);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex)
        {
            return WithDllIcon(name, dllIndex, _defaultDll, _defaultSize);
        }

        public ImageListBuilder WithDllIcon(int dllIndex)
        {
            return WithDllIcon(null, dllIndex, _defaultDll, _defaultSize);
        }

        public ImageListBuilder WithDllIcon(string name, int dllIndex, string dllPath, Size size)
        {
            int index;
            return WithDllIcon(name, dllIndex, dllPath, size, out index);
        }
        #endregion

        #region WithExtensionIcon
        public ImageListBuilder WithExtensionIcon(string ext)
        {
            int i;
            return WithExtensionIcon(ext, out i);
        }
        #endregion

        #region WithStockIcon

        public ImageListBuilder WithStockIcon(SHStockIconId stockIcon)
        {
            int index;
            return WithStockIcon(stockIcon, _defaultSize, out index);
        }

        public ImageListBuilder WithStockIcon(SHStockIconId stockIcon, out int index)
        {
            return WithStockIcon(stockIcon, _defaultSize, out index);
        }

        public ImageListBuilder WithStockIcon(SHStockIconId stockIcon, Size size)
        {
            int index;
            return WithStockIcon(stockIcon, size, out index);
        }

        #endregion

        #region WithResource
        public ImageListBuilder WithResource(string fileName)
        {
            int index;
            return WithResource(fileName, out index);
        }
        #endregion

        #region WithImage
        public ImageListBuilder WithImage(Image img)
        {
            int index;
            return WithImage(img, out index);
        }
        #endregion

        #region WithIcon

        public ImageListBuilder WithIcon(Icon ico)
        {
            int index;
            return WithIcon(ico, out index);
        }

        #endregion

        #region Utility Methods

        public Image ExtractBitmap(string ext)
        {
            return ExtractBitmap(ext, _defaultSize);
        }

        public Image ExtractBitmap(int dllIndex)
        {
            return ExtractBitmap(dllIndex, _defaultSize);
        }

        public Image ExtractBitmap(SHStockIconId stockIcon)
        {
            return ExtractBitmap(stockIcon, _defaultSize);
        }

        #endregion

    }
}
