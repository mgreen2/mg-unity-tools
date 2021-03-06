﻿using UnityEngine;
using UnityEngine.Playables;

namespace MG.UT.Timeline {
    public class FloatPlayableAsset : PlayableAsset
    {
        public FloatPlayableBehaviour template;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<FloatPlayableBehaviour>.Create(graph, template);

            return playable;
        }
    }
}