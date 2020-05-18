using System;
using System.Collections.Generic;

namespace Consulting.Common.Collections
{
    public static class IEnumerableExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }
    }
}
