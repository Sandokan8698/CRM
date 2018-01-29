using System.Linq;

namespace DUI.Helpers {
    public static class QuerableExtensions {
        public static void Load<T>(this IQueryable<T> q) { }
    }
}
