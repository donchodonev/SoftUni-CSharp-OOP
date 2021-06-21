using Collection_Hierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Models
{
    public class AddCollection : ICollectable, IAddable
    {
        public AddCollection()
            : base()
        {
            collection = new List<string>(100);
        }
        public string Add(string item)
        {
            string indexOfReturnedItem = Collection.Count.ToString();

            collection.Add(item);

            return indexOfReturnedItem;
        }
    }
}
