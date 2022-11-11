using System.Text.Json;

namespace MVC_1.CustomSessionExtensions
{
    public static class AppSessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T Value)
        {
            session.SetString(key,JsonSerializer.Serialize<T>(Value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            if (value == null)
                return default(T);
            
            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
