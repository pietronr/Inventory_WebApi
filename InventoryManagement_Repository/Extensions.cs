using InventoryManagement.Entities;
using System;

namespace InventoryManagement.Repository
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
