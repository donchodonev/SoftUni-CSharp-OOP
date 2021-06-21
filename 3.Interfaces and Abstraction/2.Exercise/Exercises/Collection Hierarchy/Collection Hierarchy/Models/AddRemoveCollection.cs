using Collection_Hierarchy.Interfaces;
using Collection_Hierarchy.Models;
using System.Collections.Generic;

namespace Collection_Hierarchy.Models
{
    public class AddRemoveCollection : ICollectable, IAddable, IRemovable
    {
        public AddRemoveCollection()
            :base()
        {
            collection = new List<string>(100);
        }
        public string Add(string item)
        {
            string indexOfReturnedItem = "0";

            if (Collection.Count == 0)
            {
                collection.Add(item);
            }
            else
            {
                collection.Insert(0, item);
            }

            return indexOfReturnedItem;
        }

        public string Remove()
        {
            string returnItem = Collection[Collection.Count - 1];

            collection.RemoveAt(Collection.Count - 1);

            return returnItem;
        }
    }
}
