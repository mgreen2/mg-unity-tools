using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT.Patterns
{
    public class ScriptableResource<T> : ScriptableObject where T : class
    {
        public T data;
    }
}