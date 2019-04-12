using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MGUT.Interpolation
{
    public class CurveInterpolator : MonoBehaviour
    {
        public float duration;
        public AnimationCurve curve;
        public InterpolateUpdateMode updateMode;

        public enum InterpolateUpdateMode { Automatic, Manual };
        [HideInInspector]                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
        public float time;

        public bool Done { get; private set; }

        public float Value { get; private set; }

        public void Reset()
        {
            time = 0;
            Done = false;
        }

        private void Update()
        {
            if (updateMode == InterpolateUpdateMode.Automatic)
            {
                if (!Done)
                    Value = Tick(Time.deltaTime);
            }
        }

        public float Tick(float deltaTime)
        {
            time += deltaTime;

            float t = time / duration;

            if (t > 1f)
            {
                t = 1f;
                Done = true;
            }

            return curve.Evaluate(t);
        }

        public float Sample(float _time)
        {
            float t = _time / duration;
            t = t > 1f ? 1f : t;
            return curve.Evaluate(t);
        }
    }
}