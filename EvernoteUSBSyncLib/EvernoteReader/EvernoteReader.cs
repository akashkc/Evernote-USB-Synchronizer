using System.Collections.Generic;
using System.Linq;
using System.IO;
using EvernoteUSBSyncLib.Constants;
using EvernoteUSBSyncLib.CustomExceptions;
using EvernoteUSBSyncLib.Models;
using EvernoteUSBSyncLib.Utils;

namespace EvernoteUSBSyncLib.EvernoteReader
{
    public class EvernoteReader : IEvernoteReader
    {
        /// <summary>
        /// Reading file items of evernote from the USB
        /// </summary>
        /// <param name="usbPath">Optional parameter to give evernote database folder path in USB</param>
        /// <returns></returns>
        public List<Item> ReadFromUSB(string usbPath = "")
        {
            var items = new List<Item>();
            var drive = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveType == DriveType.Removable).OrderBy(d=>d.Name).FirstOrDefault();

            if (drive == null) throw new USBNotFoundException();

            var directory =
                new DirectoryInfo(Path.Combine(drive.Name, Constants.EvernoteFolderLocation.DatabaseFolderName));

            if (directory.Exists)
            {
                var files = directory.GetFiles();
                items = files.ConvertFileToItemList();    
            }
            return items;
        }

        /// <summary>
        /// Read the files of Evernote Database folders and return the files in the directory
        /// </summary>
        /// <returns></returns>
        public List<Item> ReadFromLocalEvernoteFolder()
        {
            var directory = new DirectoryInfo(EvernoteFolderLocation.LocalAppLocation);
            if(!directory.Exists) throw new EvernoteLocalDatabaseFolderNotFoundException();
       
            var files = directory.GetFiles();
            List<Item> items = files.ConvertFileToItemList();
           
            return items;
        }
    }
}

