using System.Collections.Generic;
using System.IO;

namespace OSCommandExecuter.MVVM.Model
{
    public class Drive
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }
        public string Type { get; set; }
        public string TotalSize { get; set; }
        public string FreeSpace { get; set; }
        public string AvailableFreeSpace { get; set; }
        public string RootDirectory { get; set; }
        public string DriveFormat { get; set; }
        public string DriveType { get; set; }
        public string VolumeLabel { get; set; }
        public Drive () { }
        public static List<Drive> getDrives()
        {
            List<Drive> drives = new List<Drive>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                drives.Add(new Drive
                {
                    Name = drive.Name,
                    Label = drive.VolumeLabel,
                    Format = drive.DriveFormat,
                    Type = drive.DriveType.ToString(),
                    TotalSize = drive.TotalSize.ToString(),
                    FreeSpace = drive.TotalFreeSpace.ToString(),
                    AvailableFreeSpace = drive.AvailableFreeSpace.ToString(),
                    RootDirectory = drive.RootDirectory.ToString(),
                    DriveFormat = drive.DriveFormat.ToString(),
                    DriveType = drive.DriveType.ToString(),
                    VolumeLabel = drive.Name.Split(':')[0],
                });
            }

            return drives;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
