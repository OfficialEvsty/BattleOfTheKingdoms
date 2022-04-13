using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T m_instance = null;
    public static T Instance
    {
        get
        {
            if(m_instance == null)
            {
                T[] results = Resources.LoadAll<T>("ScriptableObjects");
                if (results.Length == 0)
                {
                    Debug.LogError($"SingletonScriptableObject -> Instance -> results length is 0 {typeof(T).ToString()}.");
                    return null;
                }
                if(results.Length > 1)
                {
                    Debug.LogError($"SingletonScriptableObject -> Instance -> results length is greater than 1 {typeof(T).ToString()}.");
                    return null;
                }
                m_instance = results[0];
            }
            return m_instance;
        }
    }
}
