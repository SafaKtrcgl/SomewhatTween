using System;
using System.Collections;
using UnityEngine;

namespace SomewhatTween
{
    public class SomewhatTweener
    {
        private IEnumerator _enumerator;
        private Coroutine _coroutine;
        
        private AnimationCurve _easeCurve;

        private Action _beginAction;
        private Action _completeAction;
        private Action _killAction;

        public void SetEnumerator(IEnumerator enumerator)
        {
            _enumerator = enumerator;
        }

        public void Run()
        {
            _coroutine = SomewhatTweenHandler.Instance.StartCoroutine(_enumerator);
        }

        public void Kill()
        {
            SomewhatTweenHandler.Instance.StopCoroutine(_coroutine);
            FireOnKill();
        }

        public SomewhatTweener SetOnBegin(Action action)
        {
            _beginAction = action;
            
            return this;
        }

        public void FireOnBegin()
        {
            _beginAction?.Invoke();
        }
        
        public SomewhatTweener SetOnComplete(Action action)
        {
            _completeAction = action;
            
            return this;
        }
        
        public void FireOnComplete()
        {
            _completeAction?.Invoke();
        }
        
        public SomewhatTweener SetOnKill(Action action)
        {
            _killAction = action;
            
            return this;
        }
        
        private void FireOnKill()
        {
            _killAction?.Invoke();
        }
        
        public SomewhatTweener SetEase(SomewhatEaseType easeType)
        {
            _easeCurve = SomewhatEase.GetEaseCurve(easeType);
            
            return this;
        }

        public float GetInterpolator(float normalizedTime)
        {
            return _easeCurve?.Evaluate(normalizedTime) ?? normalizedTime;
        }
    }
}
