using System.Linq;

namespace UI.Helpers {
    public static class QuerableExtensions {
        public static void Load<T>(this IQueryable<T> q) { }
    }
}
