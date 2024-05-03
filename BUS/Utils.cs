using System.Linq;

namespace BUS
{
    public static class Utils
    {
        /// <summary>
        /// Check whether all properties of object are null or empty
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(obj))
                .Any(value => string.IsNullOrEmpty(value));
        }
    }
}
