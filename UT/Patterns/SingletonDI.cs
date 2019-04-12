using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT.Patterns
{
    public class SingletonDI<T> : MonoBehaviour
    {
        public bool global;

        protected static SingletonDI<T> instance;
        protected TypeObjectDictionary components;

        protected void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                if (global)
                    Destroy(gameObject);
                else
                {
                    instance = this;
                    components.Clear();
                }
            }

            if (components == null)
            {
                components = new TypeObjectDictionary();
            }

            if (global)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        
        public static U Get<U>() where U : class
        {
            return instance.components.Get<U>();
        }

        private void OnDestroy()
        {
            components.Clear();
        }
    }
}
