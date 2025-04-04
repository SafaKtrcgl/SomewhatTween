using System;
using System.Collections;
using UnityEngine;

namespace SomewhatTween
{
    internal class SomewhatTweenHandler : MonoBehaviour
    {
        private static SomewhatTweenHandler _instance;

        internal static SomewhatTweenHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    var tweenHandler = new GameObject("SomewhatTweenHandler");
                    _instance = tweenHandler.AddComponent<SomewhatTweenHandler>();
                    DontDestroyOnLoad(tweenHandler);
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        internal static IEnumerator HandleTween(SomewhatTweener tweener, Action<float> applyAction, float duration)
        {
            tweener.FireOnBegin();
            var endOfFrame = new WaitForEndOfFrame();
            var timer = 0.0f;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                var evaluatedInterpolator = tweener.GetInterpolator(timer / duration);
                applyAction.Invoke(evaluatedInterpolator);
                yield return endOfFrame;
            }
            
            applyAction.Invoke(1);
            tweener.FireOnComplete();
        }
    }
}
