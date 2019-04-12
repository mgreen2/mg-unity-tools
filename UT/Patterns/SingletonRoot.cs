using UnityEngine;
using System.Collections;

namespace MG.UT.Patterns
{
    public class SingletonRoot<T> : MonoBehaviour where T : MonoBehaviour
    {
        public bool Global;
        public static T instance;
        protected static TypeObjectDictionary components;

        protected void Awake()
        {
            if (instance == null)
            {
                instance = this as T;

            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            if (components == null)
            {
                components = new TypeObjectDictionary();
            }

            if (Global)
                DontDestroyOnLoad(gameObject);
        }

        public static U Get<U>() where U : class
        {
            return components.Get<U>();
        }

        private void OnDestroy()
        {
            // Assume this destroys dictionary
        }
    }
}

