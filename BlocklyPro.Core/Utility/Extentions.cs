using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlocklyPro.Core.Infrastructure;

namespace BlocklyPro.Core.Utility
{
    public static class Extentions
    {
        public static Exception HandleException(this Exception exception)
        {
            return exception;
        }

        public static bool IsNull<T>(this T item)
        {
            return (item == null);
        }
        public static bool IsZeroOrNull<T>(this List<T> item)
        {
            var result = false;
            result = item.Count == 0;
            if (result)
            {
                return result;
            }

            result = (item == null);
            return result;
        }

        public static bool Is(this int item, int comparewith)
        {
            return item == comparewith;
        }

        public static bool IsNullOrEmpty<T>(this List<T> items)
        {
            if (items == null)
            {
                return true;
            }
            else if (items.Count.Is(0))
            {
                return true;
            }
            return false;
        }

        public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, List<TSource> items)
        {
            return mapper.Map<List<TSource>, List<TDestination>>(items);
        }
    }
}
