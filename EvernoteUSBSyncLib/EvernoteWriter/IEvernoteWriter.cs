using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvernoteUSBSyncLib.Models;

namespace EvernoteUSBSyncLib.EvernoteWriter
{
    public interface IEvernoteWriter
    {
        /// <summary>
        /// Responsible to write file into the USB
        /// </summary>
        /// <returns></returns>
        bool WriteToUSB(List<Item> items, string usbFolder);

        bool WriteToEvernoteLocalFolder(List<Item> items, string evernoteLocalFolde);
    }
}
