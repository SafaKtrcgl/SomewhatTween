using SomewhatTween;
using UnityEngine;

namespace SomewhatExtension
{
    public static class SomewhatExtensions
    {
        #region Move
        public static SomewhatTweener SomewhatMove(this Transform transform, Vector3 position, float duration)
        {
            var tweener = new SomewhatTweener();
            var currentPosition = transform.localPosition;
            tweener.SetEnumerator(SomewhatTweenHandler.HandleTween(tweener, (x) => transform.localPosition = Vector3.Lerp(currentPosition, position, x), duration));
            return tweener;
        }
        
        public static SomewhatTweener SomewhatMoveX(this Transform transform, float positionX, float duration)
        {
            var position = transform.position;
            return SomewhatMove(transform, new Vector3(positionX, position.y, position.z), duration);
        }
        
        public static SomewhatTweener SomewhatMoveY(this Transform transform, float positionY, float duration)
        {
            var position = transform.position;
            return SomewhatMove(transform, new Vector3(position.x, positionY, position.z), duration);
        }
        
        public static SomewhatTweener SomewhatMoveZ(this Transform transform, float positionZ, float duration)
        {
            var position = transform.position;
            return SomewhatMove(transform, new Vector3(position.x, position.y, positionZ), duration);
        }
        #endregion
        
        #region Scale
        public static SomewhatTweener SomewhatScale(this Transform transform, Vector3 scale, float duration)
        {
            var tweener = new SomewhatTweener();
            var currentScale = transform.localScale;
            tweener.SetEnumerator(SomewhatTweenHandler.HandleTween(tweener, (x) => transform.localScale = Vector3.Lerp(currentScale, scale, x), duration));
            return tweener;
        }
        
        public static SomewhatTweener SomewhatScaleX(this Transform transform, float scaleX, float duration)
        {
            var scale = transform.localScale;
            return SomewhatScale(transform, new Vector3(scaleX, scale.y, scale.z), duration);
        }
        
        public static SomewhatTweener SomewhatScaleY(this Transform transform, float scaleY, float duration)
        {
            var scale = transform.localScale;
            return SomewhatScale(transform, new Vector3(scale.x, scaleY, scale.z), duration);
        }
        
        public static SomewhatTweener SomewhatScaleZ(this Transform transform, float scaleZ, float duration)
        {
            var scale = transform.localScale;
            return SomewhatScale(transform, new Vector3(scale.x, scale.y, scaleZ), duration);
        }
        #endregion
        
        #region Rotate
        public static SomewhatTweener SomewhatRotate(this Transform transform, Vector3 rotation, float duration)
        {
            var tweener = new SomewhatTweener();
            var currentRotation = transform.localRotation.eulerAngles;

            tweener.SetEnumerator(SomewhatTweenHandler.HandleTween(tweener, (x) => transform.localRotation = Quaternion.Euler(Vector3.Lerp(currentRotation, rotation, x)), duration));
            return tweener;
        }
        
        public static SomewhatTweener SomewhatRotateX(this Transform transform, float rotationX, float duration)
        {
            var rotation = transform.localRotation.eulerAngles;
            return SomewhatRotate(transform, new Vector3(rotationX, rotation.y, rotation.z), duration);
        }
        
        public static SomewhatTweener SomewhatRotateY(this Transform transform, float rotationY, float duration)
        {
            var rotation = transform.localRotation.eulerAngles;
            return SomewhatRotate(transform, new Vector3(rotation.x, rotationY, rotation.z), duration);
        }
        
        public static SomewhatTweener SomewhatRotateZ(this Transform transform, float rotationZ, float duration)
        {
            var rotation = transform.localRotation.eulerAngles;
            return SomewhatRotate(transform, new Vector3(rotation.x, rotation.y, rotationZ), duration);
        }
        #endregion
    }
}
