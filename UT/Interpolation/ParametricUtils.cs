using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MGUT.Interpolation
{
    // Note - do not use Mathf library
    public static class MathOps {

        // Via wikipedia
        public static float Lerp(float start, float end, float t)
        {
            return (1 - t) * start + t * end;
        }

        public static float InverseLerp(float value, float start, float end)
        {
            return (value - start) / (end - start);
        }


        public static float Remap(float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            float t = InverseLerp(oldMin, oldMax, value);
            return Lerp(newMin, newMax, t);
        }
    }
}
