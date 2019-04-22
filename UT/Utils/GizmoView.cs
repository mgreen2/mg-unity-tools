using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT
{
    public class GizmoView : MonoBehaviour
    {
        public enum DrawType { Cube, Sphere, WireCube, WireSphere }
        public DrawType drawType;
        public float radius;
        public Color color;

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Vector3 center = transform.position;
            Vector3 cubeSize = new Vector3(radius, radius, radius);

            /*
            if (drawType == DrawType.Cube)
                Gizmos.DrawCube(center, cubeSize);
                */

            switch (drawType) {
                case DrawType.Cube:
                    Gizmos.DrawCube(center, cubeSize);
                    break;
                case DrawType.Sphere:
                    Gizmos.DrawSphere(center, radius);
                    break;
                case DrawType.WireCube:
                    Gizmos.DrawWireCube(center, cubeSize);
                    break;
                case DrawType.WireSphere:
                    Gizmos.DrawWireSphere(center, radius);
                    break;
            }
        }
    }
}