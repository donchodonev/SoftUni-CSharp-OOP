using Collection_Hierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace Collection_Hierarchy.Models
{
    public class MyList : ICollectable, IAddable, IRemovable
    {
        public MyList()
            : base()
        {
            collection = new List<string>(100);
        }
        public int Used => collection.Count;
        public string Add(string item)
        {
            string itemInsertIndex = "0";

            collection.Insert(0, item);

            return itemInsertIndex;
        }

        public string Remove()
        {
            string returnItem = Collection[0];

            collection.RemoveAt(0);

            return returnItem;
        }
    }
}
