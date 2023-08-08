namespace elearning.src.Shared.Infrastructure.Helper
{
    public class ObjectProperties
    {
        public static string GetObjectFullName(object obj)
        {
            return obj.GetType().ToString();
        }

        public static string GetObjectNamespace(object obj)
        {
            return obj.GetType().Namespace;
        }

        public static string GetObjectName(object obj)
        {
            return obj.GetType().Name;
        }
    }
}
