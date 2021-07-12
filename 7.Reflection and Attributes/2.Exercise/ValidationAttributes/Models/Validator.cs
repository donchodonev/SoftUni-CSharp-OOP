using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo
                    .GetCustomAttributes<MyValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
