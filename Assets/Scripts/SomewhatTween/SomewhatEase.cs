using System;
using System.Collections.Generic;
using UnityEngine;

namespace SomewhatTween
{
    public static class SomewhatEase
    {
        private const int EaseResolution = 30;
        private static readonly Dictionary<SomewhatEaseType, AnimationCurve> _easeDictionary;

        static SomewhatEase()
        {
            AnimationCurve CreateCurve(Func<float, float> easeFunc)
            {
                var keys = new Keyframe[EaseResolution + 1];
                for (int i = 0; i <= EaseResolution; i++)
                {
                    var t = i / (float)EaseResolution;
                    var value = Mathf.Clamp01(easeFunc(t));
                    keys[i] = new Keyframe(t, value);
                }
                return new AnimationCurve(keys);
            }
            
            _easeDictionary = new Dictionary<SomewhatEaseType, AnimationCurve>
            {
                { SomewhatEaseType.EaseInQuad, CreateCurve(t => t * t) },
                { SomewhatEaseType.EaseOutQuad, CreateCurve(t => t * (2 - t)) },
                { SomewhatEaseType.EaseInOutQuad, CreateCurve(t => t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t) }
            };
        }
        
        public static AnimationCurve GetEaseCurve(SomewhatEaseType easeType)
        {
            return _easeDictionary.GetValueOrDefault(easeType);
        }
    }
}
