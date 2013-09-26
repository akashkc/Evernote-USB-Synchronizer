using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteUSBSyncLib.CustomExceptions
{
    public class USBNotFoundException : Exception
    {
        public USBNotFoundException() : base("USB Not Found")
        {
            
        }
    }
}
