using SomewhatExtension;
using UnityEngine;

namespace SomewhatLauncher
{
    public class ApplicationLauncher : MonoBehaviour
    {
        private void Awake()
        {
            var foo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            foo.transform.SomewhatMove(Vector3.up * 5 + Vector3.right * 3, 2.5f, () => Debug.Log("Foo"));

            var bar = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bar.transform.SomewhatScale(Vector3.zero, 3.5f, () => Debug.Log("Bar"));
            
            var baz = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            baz.transform.SomewhatRotate(Vector3.right * 180, 1.5f, () => Debug.Log("Baz"));
        }
    }
}