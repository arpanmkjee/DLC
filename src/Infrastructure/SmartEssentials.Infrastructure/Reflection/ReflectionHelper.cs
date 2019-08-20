using System;

namespace SmartEssentials.Infrastructure.Configuration
{
    public static class ReflectionHelper
    {
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static bool CheckPrimaryKeyHasValue<T>(object src)
        {
            return CheckPropertyHasValue<T>(src, typeof(T).Name + "ID");
        }

        public static object GetPrimaryKeyValue<T>(object src)
        {
            return src.GetType().GetProperty(typeof(T).Name + "ID").GetValue(src, null);
        }

        public static bool CheckPropertyHasValue<T>(object src, string propName)
        {
            object val = src.GetType().GetProperty(propName).GetValue(src, null);
            if (val == null)
            {
                return false;
            }

            if (typeof(T) == typeof(Guid))
            {
                Guid guidVal = (Guid)val;
                if (guidVal != Guid.Empty)
                    return true;
            }
            else if (typeof(T) == typeof(int))
            {
                int intVal = (int)val;
                if (intVal > 0)
                    return true;
            }

            return false;
        }
    }
}
