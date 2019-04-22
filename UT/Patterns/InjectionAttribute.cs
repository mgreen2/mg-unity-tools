using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT.Patterns
{
    public class InjectionAttribute : PropertyAttribute
    {
        public string[] values;

        public InjectionAttribute(params string[] _values)
        {
            values = _values;
        }
    }
}