using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace MG.UT.Math
{
    public class TimeAveragedFloat
    {
        public float Sum { get; private set; }
        public float Mean { get; private set; }
        public int Count { get; private set; }

        int resolution;
        Queue<float> items;

        public TimeAveragedFloat(int _resolution)
        {
            resolution = _resolution;
            items = new Queue<float>();
            Reset();
        }

        public void Add(float value)
        {
            if (Count == resolution)
            {
                Sum -= items.Dequeue();
            }
            else
            {
                resolution++;
            }

            Sum += value;
            Mean = Sum / (int)Count;
        }

        public void Reset()
        {
            items.Clear();
            Sum = 0;
            Count = 0;
            Mean = 0;
        }
    }
}
