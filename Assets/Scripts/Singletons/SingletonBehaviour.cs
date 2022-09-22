using UnityEngine;

namespace Singletons
{
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private bool dontDestroyOnLoad = default;

        private static bool isQuitting;

        private static T instance;

        public static T Instance
        {
            get
            {
                if (isQuitting) return null;

                //Create a new T GameObject if one does not exist
                if (instance != null) return instance;

                var emptyObject = new GameObject();
                emptyObject.name = typeof(T).ToString();
                instance = emptyObject.AddComponent<T>();

                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            if (dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }

        private void OnApplicationQuit()
        {
            isQuitting = true;
        }
    }
}
