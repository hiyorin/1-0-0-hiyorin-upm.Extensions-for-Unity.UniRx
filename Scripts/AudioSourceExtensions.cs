using System;
using UnityEngine;
using UniRx;

namespace UnityExtensions.UniRx
{
    public static class AudioSourceExtensions
    {
        public static IObservable<Unit> PlayAsObservable(this AudioSource self, AudioClip clip, float volume)
        {
            if (self.Play(clip, volume))
                return Observable.Timer(TimeSpan.FromSeconds(clip.length)).AsUnitObservable();
            else
                return Observable.Throw<Unit>(new ArgumentException());
        }
    }
}
