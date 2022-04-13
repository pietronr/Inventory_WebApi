using InventoryManagement_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement_Repository
{
    internal static class Extensions
    {
        public static void SetTraceValues(this Traceable traceable)
        {
            traceable.LastWriteDate = DateTime.Now;

            if (!traceable.CreationDate.HasValue)
                traceable.CreationDate = traceable.LastWriteDate;
        }

        public static void SetUpdateValues(this Traceable traceable)
        {
            traceable.LastWriteDate = DateTime.Now;
        }
    }
}
