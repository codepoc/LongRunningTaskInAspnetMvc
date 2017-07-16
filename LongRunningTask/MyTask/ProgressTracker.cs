using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LongRunningTask.MyTask
{
    public class ProgressTracker
    {
        private static Hashtable Status = new Hashtable();

        public static object getValue(Guid itemId)
        {
            return Status[itemId];
        }

        public static void add(Guid ItemId, object oStatus)
        {
            //Make sure that oStatus contains only the values 0 through 100 or -1
            Status[ItemId] = oStatus;
        }

        public static void update(Guid ItemId, object oStatus)
        {
            //Make sure that oStatus contains only the values 0 through 100 or -1
            Status[ItemId] = oStatus;
        }

        public static void remove(Guid ItemId)
        {
            Status.Remove(ItemId);
        }

        public static bool contains(Guid ItemId)
        {
            return Status.Contains(ItemId);
        }
    }
}
