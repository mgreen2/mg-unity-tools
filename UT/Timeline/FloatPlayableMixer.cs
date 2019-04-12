using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MGUT.Timeline {
    public class FloatPlayableMixer : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            // Retrieve bound object, declare variables to change.
            FloatPlayableBinding trackBindingFloat = playerData as FloatPlayableBinding;
            float finalValue = 0f;

            if (!trackBindingFloat)
                return;

            int inputCount = playable.GetInputCount();

            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                // Retrieve playable
                ScriptPlayable<FloatPlayableBehaviour> inputPlayable = (ScriptPlayable<FloatPlayableBehaviour>)playable.GetInput(i);
                FloatPlayableBehaviour input = inputPlayable.GetBehaviour();

                finalValue += input.value * inputWeight;
            }

            trackBindingFloat.ApplyFloat(finalValue);
        }
    }
}