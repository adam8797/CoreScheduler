using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Quartz;

namespace CoreScheduler.Server.Utilities
{
    public static class Util
    {
        public static IEnumerable MoveUp(this IEnumerable enumerable, int itemIndex)
        {
            int i = 0;

            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                i++;

                if (itemIndex.Equals(i))
                {
                    object previous = enumerator.Current;

                    if (enumerator.MoveNext())
                    {
                        yield return enumerator.Current;
                    }

                    yield return previous;

                    break;
                }

                yield return enumerator.Current;
            }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static Dictionary<TKey, List<TValue>> Bin<TKey, TValue>(this IEnumerable<TValue> list,
            Func<TValue, TKey> keyFunc)
        {
            var dict = new Dictionary<TKey, List<TValue>>();

            foreach (var value in list)
            {
                var key = keyFunc(value);

                if (dict.ContainsKey(key))
                    dict[key].Add(value);
                else
                    dict.Add(key, new List<TValue>() { value });
            }

            return dict;
        }

        public static void ForEach<T>(this IList list, Action<T> act)
        {
            var item = list.Cast<T>().ToList();

            foreach (var i in item)
            {
                act(i);
            }
        }

        public static void ForEach<T>(this IEnumerable list, Action<T> act)
        {
            var item = list.Cast<T>().ToList();

            foreach (var i in item)
            {
                act(i);
            }
        }

        public static void ForEach<T>(this IList<T> list, Action<T> act)
        {
            foreach (var i in list)
            {
                act(i);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> act)
        {
            foreach (var i in list)
            {
                act(i);
            }
        }

        public static T UnsafeGet<T>(this JobDataMap map, string key)
        {
            return (T) map[key];
        }

        public static T SafeGet<T>(this JobDataMap map, string key)
        {
            if (map.ContainsKey(key))
                return (T)map[key];
            return default(T);
        }

        public static bool IsAny<T>(this T q, params T[] options) where T: class
        {
            return options.Any(x => q == x);
        }

        public static JobBuilder WithDataMapDictionary(this JobBuilder builder, IDictionary<string, object> dict)
        {
            return builder.UsingJobData(new JobDataMap(dict));
        }

        public static T GetAttribute<T>(this Type t) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(t, typeof(T));
        }

        public static bool HasAttribute<T>(this Type t) where T : Attribute
        {
            return Attribute.IsDefined(t, typeof(T));
        }

        /// <summary>
        /// Copies an object by coping all of its public properties
        /// </summary>
        /// <typeparam name="T">Type of the object to copy</typeparam>
        /// <param name="t">Object to copy</param>
        /// <returns>Shallow Copy of input object</returns>
        public static T ShallowCopy<T>(this T t) where T: class, new()
        {
            var newT = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(newT, prop.GetValue(t));
            }

            return newT;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}
