using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }
    public virtual void Awake()
    {
        if (instance != this && instance != null) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance=findInstance();
        }
    }

    private T findInstance()
    {
        return FindFirstObjectByType<T>();
    }

}
