using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Models
{

    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
