using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace MGUT.Timeline
{
    [TrackClipType(typeof(FloatPlayableAsset))]
    [TrackBindingType(typeof(FloatPlayableBinding))]
    public class FloatPlayableTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<FloatPlayableMixer>.Create(graph, inputCount);
        }
    }
}
