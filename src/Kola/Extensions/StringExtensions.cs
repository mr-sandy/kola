
namespace Kola.Extensions
{
    internal static class StringExtensions
    {
        public static string Urlify(this string raw)
        {
            return string.IsNullOrEmpty(raw) 
                ? string.Empty 
                : raw.ToLower().Replace(" ", "-");
        }

    }
}