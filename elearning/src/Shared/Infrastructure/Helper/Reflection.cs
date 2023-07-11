using System;
namespace elearning.src.Shared.Infrastructure.Helper
{
    public class Reflection
    {
        public static object GetObjectProperty(object obj, string property)
        {
            Type t = obj.GetType();
            var p = t.GetProperty(property);
            var value = p.GetValue(obj, null);
            return value;
        }
    }
}
