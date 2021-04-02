using SCI.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class ReflectionExtensions {

        public static string ToRatePropertyName(this string priorityPropertyName) {
            return priorityPropertyName.Replace(
                ReflectionStrings.PRIORITY_PROPERTY_SUFFIX,
                ReflectionStrings.RATE_PROPERTY_SUFFIX);
        }
    }
}
