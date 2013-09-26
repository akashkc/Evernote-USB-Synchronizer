using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EvernoteUSBSyncLib.Models;

namespace EvernoteUSBSyncLib.EvernoteReader
{
    public interface IEvernoteReader
    {
        List<Item> ReadFromUSB(string usbPath);

        List<Item> ReadFromLocalEvernoteFolder();
    }
}
