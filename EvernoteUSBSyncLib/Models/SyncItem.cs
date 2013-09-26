using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteUSBSyncLib.Models
{
    class SyncItem
    {
        public Item Item { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }
    }
}
