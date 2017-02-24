using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreScheduler.Server.ApiImpl
{
    public class Manager<T> : MarshalByRefObject
    {
        protected IDictionary<string, T> Dictionary;

        public Manager(IDictionary<string, T> values)
        {
            Dictionary = values;
        }

        public T this[int index]
        {
            get { return Dictionary.Values.ElementAt(index); }
        }

        public T this[string key]
        {
            get { return Dictionary[key]; }
        }

        public int Count()
        {
            return Dictionary.Count;
        }

        public bool ContainsKey(string key)
        {
            return Dictionary.ContainsKey(key);
        }

        public IEnumerable<T> AsEnumerable()
        {
            return Dictionary.Values.AsEnumerable();
        }
    }
}
