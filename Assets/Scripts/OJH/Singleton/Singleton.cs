using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spear
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = typeof(T).ToString() + " (Singleton)";
                    
                        DontDestroyOnLoad(singleton);
                    }
                }
                return _instance;
            }
        }
    }
}
