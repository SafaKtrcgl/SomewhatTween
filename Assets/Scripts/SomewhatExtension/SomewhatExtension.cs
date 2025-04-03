using System;
using System.Collections;
using SomewhatTween;
using UnityEngine;

namespace SomewhatExtension
{
    public static class SomewhatExtensions
    {
        #region Move
        public static void SomewhatMove(this Transform transform, Vector3 position, float duration, Action onComplete = null)
        {
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatMoveInternal(transform, position, duration, onComplete));
        }
        
        public static void SomewhatMoveX(this Transform transform, float positionX, float duration, Action onComplete = null)
        {
            var position = transform.position;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatMoveInternal(transform, new Vector3(positionX, position.y, position.z), duration, onComplete));
        }
        
        public static void SomewhatMoveY(this Transform transform, float positionY, float duration, Action onComplete = null)
        {
            var position = transform.position;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatMoveInternal(transform, new Vector3(position.x, positionY, position.z), duration, onComplete));
        }
        
        public static void SomewhatMoveZ(this Transform transform, float positionZ, float duration, Action onComplete = null)
        {
            var position = transform.position;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatMoveInternal(transform, new Vector3(position.x, position.y, positionZ), duration, onComplete));
        }

        private static IEnumerator SomewhatMoveInternal(Transform transform, Vector3 position, float duration, Action onComplete = null)
        {
            var endOfFrame = new WaitForEndOfFrame();
            var timer = 0.0f;
            var startPosition = transform.position;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, position, timer / duration);
                yield return endOfFrame;
            }
            
            transform.position = position;
            onComplete?.Invoke();
        }
        #endregion
        
        #region Scale
        public static void SomewhatScale(this Transform transform, Vector3 scale, float duration, Action onComplete = null)
        {
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatScaleInternal(transform, scale, duration, onComplete));
        }
        
        public static void SomewhatScaleX(this Transform transform, float scaleX, float duration, Action onComplete = null)
        {
            var scale = transform.localScale;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatScaleInternal(transform, new Vector3(scaleX, scale.y, scale.z), duration, onComplete));
        }
        
        public static void SomewhatScaleY(this Transform transform, float scaleY, float duration, Action onComplete = null)
        {
            var scale = transform.localScale;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatScaleInternal(transform, new Vector3(scale.x, scaleY, scale.z), duration, onComplete));
        }
        
        public static void SomewhatScaleZ(this Transform transform, float scaleZ, float duration, Action onComplete = null)
        {
            var scale = transform.localScale;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatScaleInternal(transform, new Vector3(scale.x, scale.y, scaleZ), duration, onComplete));
        }

        private static IEnumerator SomewhatScaleInternal(Transform transform, Vector3 scale, float duration, Action onComplete = null)
        {
            var endOfFrame = new WaitForEndOfFrame();
            var timer = 0.0f;
            var startScale = transform.localScale;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, scale, timer / duration);
                yield return endOfFrame;
            }

            transform.localScale = scale;
            onComplete?.Invoke();
        }
        #endregion
        
        #region Rotate
        public static void SomewhatRotate(this Transform transform, Vector3 rotation, float duration, Action onComplete = null)
        {
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatRotateInternal(transform, rotation, duration, onComplete));
        }
        
        public static void SomewhatRotateX(this Transform transform, float rotationX, float duration, Action onComplete = null)
        {
            var rotation = transform.localRotation.eulerAngles;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatRotateInternal(transform, new Vector3(rotationX, rotation.y, rotation.z), duration, onComplete));
        }
        
        public static void SomewhatRotateY(this Transform transform, float rotationY, float duration, Action onComplete = null)
        {
            var rotation = transform.localRotation.eulerAngles;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatRotateInternal(transform, new Vector3(rotation.x, rotationY, rotation.z), duration, onComplete));
        }
        
        public static void SomewhatRotateZ(this Transform transform, float rotationZ, float duration, Action onComplete = null)
        {
            var rotation = transform.localRotation.eulerAngles;
            SomewhatTweenHandler.Instance.StartCoroutine(SomewhatRotateInternal(transform, new Vector3(rotation.x, rotation.y, rotationZ), duration, onComplete));
        }

        private static IEnumerator SomewhatRotateInternal(Transform transform, Vector3 rotation, float duration, Action onComplete = null)
        {
            var endOfFrame = new WaitForEndOfFrame();
            var timer = 0.0f;
            var startRotation = transform.localRotation.eulerAngles;

            while (timer < duration)
            {
                timer += Time.deltaTime;
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, rotation, timer / duration));
                yield return endOfFrame;
            }

            transform.localRotation = Quaternion.Euler(rotation);
            onComplete?.Invoke();
        }
        #endregion
    }
}
