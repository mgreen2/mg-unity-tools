using System;
using System.Collections.Generic;

namespace MG.UT.Patterns
{
    public class TypeObjectDictionary
    {
        Dictionary<Type, object> dictionary;
        public TypeObjectDictionary()
        {
            dictionary = new Dictionary<Type, object>();
        }

        public T Get<T>() where T : class
        {
            if (dictionary.TryGetValue(typeof(T), out object item)) {
                return item as T;
            }
            return null;
        }

        public void Add<T>(object item)
        {
            dictionary.Add(typeof(T), item);
        }

        public void Clear()
        {
            dictionary.Clear();
        }
    }
}
