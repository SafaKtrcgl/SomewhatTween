using UnityEngine;

namespace SomewhatTween
{
    public class SomewhatTweenHandler : MonoBehaviour
    {
        private static SomewhatTweenHandler _instance;

        public static SomewhatTweenHandler Instance
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
    }
}
