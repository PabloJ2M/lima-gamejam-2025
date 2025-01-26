using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class SingletonBasic<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake() => Instance = this as T;
}

[DefaultExecutionOrder(-500)]
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        //create singleton
        if (Instance) { Destroy(gameObject); return; }
        
        Instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}

[DefaultExecutionOrder(-500)]
public abstract class SingletonComplex<T> : MonoBehaviour where T : Component
{
    private enum Type { DestroyNew, DestroyOld, DestroyBoth }
    [SerializeField] private Type _type = Type.DestroyNew;
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        //create singleton
        if (Instance)
        {
            if (_type == Type.DestroyOld || _type == Type.DestroyBoth) Destroy(Instance);
            if (_type == Type.DestroyNew || _type == Type.DestroyBoth) { Destroy(gameObject); return; }
        }
        else
        {
            if (_type == Type.DestroyBoth) { Destroy(gameObject); return; }
        }

        Instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}