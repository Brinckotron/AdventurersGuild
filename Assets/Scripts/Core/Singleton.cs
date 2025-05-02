using UnityEngine;

/// <summary>
/// Generic Singleton class for MonoBehaviour-derived classes.
/// Inherit from this class to create a singleton of type T.
/// Example usage: public class YourManager : Singleton<YourManager> { }
/// </summary>
/// <typeparam name="T">The type of MonoBehaviour that will be a singleton</typeparam>
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Static instance reference
    private static T _instance;
    
    // Static accessor property with thread safety using double-check locking
    public static T Instance
    {
        get
        {
            // First check - avoid locking if instance already exists
            if (_instance == null)
            {
                // Find existing instance in scene
                _instance = FindFirstObjectByType<T>();
                
                // If no instance exists, create one
                if (_instance == null)
                {
                    // Create a new game object and add component of type T
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                    
                    Debug.Log($"[Singleton] An instance of {typeof(T)} was created.");
                }
            }
            
            return _instance;
        }
    }
    
    /// <summary>
    /// Override this method to make it virtual and allow child classes to extend it
    /// while still maintaining base singleton functionality
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
            
            OnAwake();
            
            Debug.Log($"[Singleton] {typeof(T)} instance ready.");
        }
        else if (_instance != this)
        {
            // If an instance already exists that isn't this one, destroy this one
            Debug.LogWarning($"[Singleton] Attempting to create another instance of {typeof(T)}. Destroying duplicate.");
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Virtual method that can be overridden by child classes to initialize after singleton setup
    /// </summary>
    protected virtual void OnAwake() 
    {
        // Override this in derived classes for initialization logic
    }
    
    /// <summary>
    /// Virtual method that will be called on application quit
    /// </summary>
    protected virtual void OnApplicationQuit()
    {
        _instance = null;
    }
}