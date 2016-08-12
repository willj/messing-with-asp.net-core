using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helpers
{
    public class BoolMustBeTrueAttribute : ValidationAttribute
    {
        public BoolMustBeTrueAttribute()
        {
            ErrorMessage = "{0} must be true";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;    // convention to return true when null, so as to not enforce field to be required, maybe questionable here...
            }

            return (bool)value;
        }
    }
}
