using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteUSBSyncLib.CustomExceptions
{
    public class UpdatedFileAlreadyExist : Exception
    {
        public UpdatedFileAlreadyExist() : base("Updated File already exist.")
        {
            
        }
    }
}
