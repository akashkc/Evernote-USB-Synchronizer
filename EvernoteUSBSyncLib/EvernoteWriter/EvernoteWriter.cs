using System;
using System.Collections.Generic;
using System.Linq;
using EvernoteUSBSyncLib.CustomExceptions;
using EvernoteUSBSyncLib.Models;
using System.IO;

namespace EvernoteUSBSyncLib.EvernoteWriter
{
    public class EvernoteWriter : IEvernoteWriter
    {
        public bool WriteToUSB(List<Item> items, string usbFolder = "")
        {
            if (string.IsNullOrEmpty(usbFolder))
            {
                var drive =
                    DriveInfo.GetDrives()
                             .Where(d => d.IsReady && d.DriveType == DriveType.Removable)
                             .OrderBy(d => d.Name).FirstOrDefault();
                if (drive != null)
                    usbFolder = Path.Combine(drive.Name, Constants.EvernoteFolderLocation.DatabaseFolderName);
                else
                    throw new USBNotFoundException();
            }

            if (string.IsNullOrEmpty(usbFolder)) return false;

            var directory = new DirectoryInfo(usbFolder);
            if (!directory.Exists) directory.Create();

            try
            {
                foreach (Item item in items)
                {
                    File.Copy(item.Location, Path.Combine(directory.FullName, item.FileName), true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Migrates file from USB to evernote local folder
        /// </summary>
        /// <param name="items"></param>
        /// <param name="evernoteLocalFolder"></param>
        /// <returns></returns>
        public bool WriteToEvernoteLocalFolder(List<Item> items, string evernoteLocalFolder = "")
        {
            if (string.IsNullOrEmpty(evernoteLocalFolder))
                evernoteLocalFolder = Constants.EvernoteFolderLocation.LocalAppLocation;

            var directory = new DirectoryInfo(evernoteLocalFolder);
            
            if(directory.Exists)
            {
                foreach(Item item in items)
                {
                    try
                    {
                        File.Copy(item.Location, Path.Combine(evernoteLocalFolder, item.FileName), true);
                    }
                    catch(Exception ex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
