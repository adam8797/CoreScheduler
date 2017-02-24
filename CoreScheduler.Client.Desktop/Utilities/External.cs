using System;
using System.Runtime.InteropServices;

namespace CoreScheduler.Client.Desktop.Utilities
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFileInfo
    {
        public const int Namesize = 80;
        public readonly IntPtr hIcon;
        public readonly int iIcon;
        public readonly uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public readonly string szDisplayName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Namesize)]
        public readonly string szTypeName;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHStockIconInfo
    {
        public UInt32 cbSize;
        public IntPtr hIcon;
        public Int32 iSysIconIndex;
        public Int32 iIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szPath;
    }

    [Flags]
    public enum SHGSI : uint
    {
        IconLocation = 0,
        Icon = 0x000000100,
        SysIconIndex = 0x000004000,
        LinkOverlay = 0x000008000,
        Selected = 0x000010000,
        LargeIcon = 0x000000000,
        SmallIcon = 0x000000001,
        ShellIconSize = 0x000000004,
        UseFileAttributes = 0x000000010,
        FileAttributeNormal = 0x00000080
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator System.Drawing.Point(POINT p)
        {
            return new System.Drawing.Point(p.X, p.Y);
        }

        public static implicit operator POINT(System.Drawing.Point p)
        {
            return new POINT(p.X, p.Y);
        }
    }

    [ComImport()]
    [Guid("46EB5926-582E-4017-9FDF-E8998DAA0950")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //helpstring("Image List"),
    public interface IImageList
    {
        [PreserveSig]
        int Add(
            IntPtr hbmImage,
            IntPtr hbmMask,
            ref int pi);

        [PreserveSig]
        int ReplaceIcon(
            int i,
            IntPtr hicon,
            ref int pi);

        [PreserveSig]
        int SetOverlayImage(
            int iImage,
            int iOverlay);

        [PreserveSig]
        int Replace(
            int i,
            IntPtr hbmImage,
            IntPtr hbmMask);

        [PreserveSig]
        int AddMasked(
            IntPtr hbmImage,
            int crMask,
            ref int pi);

        [PreserveSig]
        int Draw(
            ref IMAGELISTDRAWPARAMS pimldp);

        [PreserveSig]
        int Remove(
        int i);

        [PreserveSig]
        int GetIcon(
            int i,
            int flags,
            ref IntPtr picon);

        [PreserveSig]
        int GetImageInfo(
            int i,
            ref IMAGEINFO pImageInfo);

        [PreserveSig]
        int Copy(
            int iDst,
            IImageList punkSrc,
            int iSrc,
            int uFlags);

        [PreserveSig]
        int Merge(
            int i1,
            IImageList punk2,
            int i2,
            int dx,
            int dy,
            ref Guid riid,
            ref IntPtr ppv);

        [PreserveSig]
        int Clone(
            ref Guid riid,
            ref IntPtr ppv);

        [PreserveSig]
        int GetImageRect(
            int i,
            ref RECT prc);

        [PreserveSig]
        int GetIconSize(
            ref int cx,
            ref int cy);

        [PreserveSig]
        int SetIconSize(
            int cx,
            int cy);

        [PreserveSig]
        int GetImageCount(
        ref int pi);

        [PreserveSig]
        int SetImageCount(
            int uNewCount);

        [PreserveSig]
        int SetBkColor(
            int clrBk,
            ref int pclr);

        [PreserveSig]
        int GetBkColor(
            ref int pclr);

        [PreserveSig]
        int BeginDrag(
            int iTrack,
            int dxHotspot,
            int dyHotspot);

        [PreserveSig]
        int EndDrag();

        [PreserveSig]
        int DragEnter(
            IntPtr hwndLock,
            int x,
            int y);

        [PreserveSig]
        int DragLeave(
            IntPtr hwndLock);

        [PreserveSig]
        int DragMove(
            int x,
            int y);

        [PreserveSig]
        int SetDragCursorImage(
            ref IImageList punk,
            int iDrag,
            int dxHotspot,
            int dyHotspot);

        [PreserveSig]
        int DragShowNolock(
            int fShow);

        [PreserveSig]
        int GetDragImage(
            ref POINT ppt,
            ref POINT pptHotspot,
            ref Guid riid,
            ref IntPtr ppv);

        [PreserveSig]
        int GetItemFlags(
            int i,
            ref int dwFlags);

        [PreserveSig]
        int GetOverlayImage(
            int iOverlay,
            ref int piIndex);
    };

    public struct IMAGELISTDRAWPARAMS
    {
        public int cbSize;
        public IntPtr himl;
        public int i;
        public IntPtr hdcDst;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public int xBitmap;        // x offest from the upperleft of bitmap
        public int yBitmap;        // y offset from the upperleft of bitmap
        public int rgbBk;
        public int rgbFg;
        public int fStyle;
        public int dwRop;
        public int fState;
        public int Frame;
        public int crEffect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGEINFO
    {
        public IntPtr hbmImage;
        public IntPtr hbmMask;
        public int Unused1;
        public int Unused2;
        public RECT rcImage;
    }


    public enum SHStockIconId : uint
    {
        DocNoAssoc = 0,
        DocAssoc = 1,
        Application = 2,
        Folder = 3,
        FolderOpen = 4,
        Drive525 = 5,
        Drive35 = 6,
        DriveRemove = 7,
        DriveFixed = 8,
        DriveNet = 9,
        DriveNetDisabled = 10,
        DriveCD = 11,
        DriveRam = 12,
        World = 13,
        InternetOptions = 14,
        Server = 15,
        Printer = 16,
        MyNetwork = 17,
        Network = 18,
        Thingy = 19,
        ClockPage = 20,
        ControlPanel = 21,
        Find = 22,
        Help = 23,
        Run = 24,
        Screen = 25,
        RemoveDevice = 26,
        Power = 27,
        Share = 28,
        Link = 29,
        SlowFile = 30,
        Recycler = 31,
        RecyclerFull = 32,
        WeirdFolder = 33,
        Desktop = 34,
        ControlPanel2 = 35,
        Thingy2 = 36,
        Printers = 37,
        Fonts = 38,
        StartMenu = 39,
        MediaCDAudio = 40,
        Tree = 41,
        ComputerFolder = 42,
        Favorites = 43,
        LogOff = 44,
        UpFolder = 45,
        WindowsUpdate = 46,
        Lock = 47,
        Thingy3 = 48,
        Autolist = 49,
        PrinterNet = 50,
        ServerShare = 51,
        PrinterFax = 52,
        PrinterFaxNet = 53,
        PrinterFile = 54,
        Stack = 55,
        Mediasvcd = 56,
        StuffedFolder = 57,
        DriveUnknown = 58,
        DriveDvd = 59,
        MediaDvd = 60,
        MediaDvdRam = 61,
        MediaDvdRW = 62,
        MediaDvdR = 63,
        MediaDvdRom = 64,
        MediaCDAudioPlus = 65,
        MediaCDRW = 66,
        MediaCDR = 67,
        MediaCDBurn = 68,
        MediaBlankCD = 69,
        MediaCDRom = 70,
        AudioFiles = 71,
        ImageFiles = 72,
        VideoFiles = 73,
        MixedFiles = 74,
        FolderBack = 75,
        FolderFront = 76,
        Shield = 77,
        Warning = 78,
        Info = 79,
        Error = 80,
        Key = 81,
        Software = 82,
        Rename = 83,
        Delete = 84,
        MediaAudioDVD = 85,
        MediaMovieDVD = 86,
        MediaEnhancedCD = 87,
        MediaEnhancedDVD = 88,
        MediaHDDVD = 89,
        MediaBluray = 90,
        MediaVCD = 91,
        MediaDVDPlusR = 92,
        MediaDVDPlusRW = 93,
        DesktopPC = 94,
        MobilePC = 95,
        Users = 96,
        MediaSmartMedia = 97,
        MediaCompactFlash = 98,
        DeviceCellPhone = 99,
        DeviceCamera = 100,
        DeviceVideoCamera = 101,
        DeviceAudioPlayer = 102,
        NetworkConnect = 103,
        Internet = 104,
        ZipFile = 105,
        Settings = 106,
        WindowsHardDrive = 107,
        AddRemovePrograms = 108,
        MusicFolder = 109,
        VideoFolder = 110,
        VideoFolder2 = 111,
        SearchFolder = 112,
        AddPrinter = 113,
        Tree2 = 114,
        Blank = 115,
        ProjectorScreen = 116,
        NetworkPrinterOk = 117,
        PrinterFileOk = 118,
        NetworkFaxOk = 119,
        PrinterOk = 120,
        FaxOk = 121,
        LinedPage = 122,
        Envelope = 123,
        WindowWithPicture = 124,
        MusicFile = 125,
        MovieFile = 126,
        People = 127,
        InfoShield = 128,
        ErrorShield = 129,
        OkShield = 130,
        WarningShield = 131,
        DriveHDDVD = 132,
        DriveBD = 133,
        MediaHDDVDRom = 134,
        MediaHDDVDR = 135,
        MediaHDDVDRam = 136,
        MediaBDRom = 137,
        MediaBDR = 138,
        MediaBDRE = 139,
        ClusteredDrive = 140,
        // Many variations on the clusteredDrive from 140-159
        // no icons from 160-162
        MusicFile2 = 163,
        DriveLightUnlocked = 164,
        DriveLightLocked = 165,
        DriveLightUnlockedAlert = 166,
        DriveUnlocked = 167,
        DriveUnlockedAlert = 168,
        DriveUnlockedDark = 169,
        DriveLockedDark = 170,
        DriveUnlockedDarkAlert = 171,
        ImagePage = 172,
        SmallCheck = 173,
        MaxIcons = 175
    }
}
