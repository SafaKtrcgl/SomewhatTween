using System;
using SomewhatExtension;
using SomewhatTween;
using UnityEngine;

namespace SomewhatLauncher
{
    public class ApplicationLauncher : MonoBehaviour
    {
        private SomewhatTweener _tweenerToKill;
        private void Awake()
        {
            var foo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foo.transform.SomewhatMove(Vector3.up * 5 + Vector3.right * 3, 2.5f)
                .SetOnBegin(() => Debug.Log("foo begin"))
                .SetOnComplete(() => Debug.Log("foo complete"))
                .Run();
            
            var foo1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foo1.transform.position = Vector3.down;
            foo1.transform.SomewhatMove(Vector3.up * 4 + Vector3.right * 3, 2.5f)
                .SetOnBegin(() => Debug.Log("foo1 begin"))
                .SetOnComplete(() => Debug.Log("foo1 complete"))
                .SetEase(SomewhatEaseType.EaseInQuad)
                .Run();
            
            var foo2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foo2.transform.position = Vector3.down * 2;
            foo2.transform.SomewhatMove(Vector3.up * 3 + Vector3.right * 3, 2.5f)
                .SetOnBegin(() => Debug.Log("foo2 begin"))
                .SetOnComplete(() => Debug.Log("foo2 complete"))
                .SetEase(SomewhatEaseType.EaseOutQuad)
                .Run();
            
            var foo3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foo3.transform.position = Vector3.down * 3;
            foo3.transform.SomewhatMove(Vector3.up * 2 + Vector3.right * 3, 2.5f)
                .SetOnBegin(() => Debug.Log("foo3 begin"))
                .SetOnComplete(() => Debug.Log("foo3 complete"))
                .SetEase(SomewhatEaseType.EaseInOutQuad)
                .Run();

            var bar = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bar.transform.position = Vector3.left * 1;
            _tweenerToKill = bar.transform.SomewhatScale(Vector3.zero, 3.5f)
                .SetOnBegin(() => Debug.Log("bar begin"))
                .SetOnComplete(() => Debug.Log("bar complete"))
                .SetOnKill(() => Debug.Log("bar dead"));
            _tweenerToKill.Run();
            
            var baz = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            baz.transform.position = Vector3.left * 2;
            baz.transform.SomewhatRotate(Vector3.right * 180, 1.5f)
                .SetOnBegin(() => Debug.Log("baz begin"))
                .SetOnComplete(() => Debug.Log("baz complete"))
                .Run();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _tweenerToKill.Kill();
            }
        }
    }
}