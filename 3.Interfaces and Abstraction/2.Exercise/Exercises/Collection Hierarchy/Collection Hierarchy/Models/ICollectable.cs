using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection_Hierarchy.Models
{
    public abstract class ICollectable : IEnumerable
    {
        protected ICollectable()
        {
            collection = new List<string>(100);
        }
        protected List<string> collection;
        protected IReadOnlyList<string> Collection
        {
            get => collection.AsReadOnly();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }
    }
}
