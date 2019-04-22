using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace MG.UT.Patterns
{
    [CustomPropertyDrawer(typeof(InjectionAttribute))]
    public class InjectionAttributeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return base.CreatePropertyGUI(property);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InjectionAttribute inject = (InjectionAttribute)attribute;
            GUIStyle b = new GUIStyle();
            b.fontStyle = FontStyle.Bold;
            GUI.Label(position, "INJECTIONS", b);
            position.x += 100f;
            GUIStyle g = new GUIStyle();
            g.fontStyle = FontStyle.Italic;

            for (int i = 0; i < inject.values.Length; i++)
            {
                GUI.Label(position, inject.values[i], g);
                position.x += 100f;
            }
        }
    
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}