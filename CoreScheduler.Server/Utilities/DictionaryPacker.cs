using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CoreScheduler.Server.Attributes;

namespace CoreScheduler.Server.Utilities
{

    public static class DictionaryPacker
    {
        private const char SplitChar = ';';

        #region Convienience Methods

        public static object Unpack(this IDictionary<string, object> map, Type target, string prefix = null)
        {
            var o = Activator.CreateInstance(target);
            return Unpack(map, target, o, prefix);
        }

        public static T Unpack<T>(this IDictionary<string, object> map, string prefix = null) where T : class, new()
        {
            return (T) Unpack(map, typeof(T), new T(), prefix);
        }

        public static void Pack<T>(this IDictionary<string, object> dict, T tObj, string prefix = null) where T : class, new()
        {
            Pack(dict, tObj, tObj.GetType(), prefix);
        }
        #endregion

        private static IEnumerable<Tuple<PropertyInfo, Type>> GetProps(Type t)
        {
            if (t.BaseType == typeof(object))
                return t.GetProperties().Select(x => Tuple.Create(x, t));
            else if (Attribute.IsDefined(t, typeof(PackableAttribute)))
                return
                    t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                    BindingFlags.Static | BindingFlags.DeclaredOnly)
                        .Select(x => Tuple.Create(x, t))
                        .Concat(GetProps(t.BaseType)).ToArray();
            else return Enumerable.Empty<Tuple<PropertyInfo, Type>>();
        }

        public static object Unpack(this IDictionary<string, object> map, Type tType, object tObj, string prefix = null)
        {
            var props = GetProps(tType);

            foreach (var pair in props)
            {
                var propertyInfo = pair.Item1;
                var baseType = pair.Item2;

                var keyName = MakeKey(propertyInfo, baseType, prefix);

                if (map.ContainsKey(keyName))
                {
                    if (propertyInfo.PropertyType.IsAssignableFrom(typeof(string[])))
                    {
                        propertyInfo.SetValue(tObj, ((string)map[keyName]).Split(SplitChar).Where(x => !string.IsNullOrEmpty(x)).ToArray());
                    }
                    else if (Attribute.IsDefined(propertyInfo.PropertyType, typeof(PackableAttribute)))
                    {
                        var inst = Activator.CreateInstance(propertyInfo.PropertyType);
                        propertyInfo.SetValue(tObj, Unpack(map, propertyInfo.PropertyType, inst, keyName));
                    }
                    else
                    {
                        var method = propertyInfo.GetSetMethod();
                        if (method != null)
                            method.Invoke(tObj, new [] { map[keyName] });
                    }
                }
            }

            return tObj;
        }

        public static void Pack(this IDictionary<string, object> dict, object tObj, Type tType, string prefix = null)
        {
            var props = GetProps(tType);

            foreach (var pair in props)
            {
                var propertyInfo = pair.Item1;
                var baseType = pair.Item2;

                var keyName = MakeKey(propertyInfo, baseType, prefix);

                if (propertyInfo.PropertyType.IsAny(typeof(bool), typeof(double), typeof(float), typeof(int), typeof(long), typeof(string)))
                    dict.Add(keyName, propertyInfo.GetValue(tObj));

                else if (propertyInfo.PropertyType == typeof(string[]))
                    dict.Add(keyName, string.Join(SplitChar + "", (string[]) propertyInfo.GetValue(tObj) ?? new string[0]));

                else if (propertyInfo.PropertyType.IsEnum)
                    dict.Add(keyName, (int)propertyInfo.GetValue(tObj));

                else if (Attribute.IsDefined(propertyInfo.PropertyType, typeof(PackableAttribute)))
                {
                    dict.Add(keyName, null);
                    dict.Pack(propertyInfo.GetValue(tObj), propertyInfo.PropertyType, keyName);
                }
            }
        }

        private static string MakeKey(PropertyInfo propertyInfo, Type tType, string prefix = null)
        {
            if (string.IsNullOrEmpty(prefix))
                return tType.Name + "." + propertyInfo.Name;
            else
                return prefix + "." + propertyInfo.Name;
        }
    }
}
