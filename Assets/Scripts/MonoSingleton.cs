using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (Application.isPlaying)
                {
                    //Debug.Log($"{new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name}'dan gelen cagri sebebiyle {typeof(T).FullName} instance'i atanmaya calisiliyor");
                }
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    //Debug.Log($"{typeof(T).FullName} instance'i bulunamadi");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
    }
}