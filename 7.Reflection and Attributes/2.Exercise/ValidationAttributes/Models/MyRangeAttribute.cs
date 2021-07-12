using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Models
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        private readonly int minValue;
        private readonly int maxValue;
        public override bool IsValid(object obj)
        {
            int num = Convert.ToInt32(obj);
            
            return num >= minValue && num <= maxValue;
        }
    }
}
