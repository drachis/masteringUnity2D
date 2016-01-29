using UnityEngine;
using System.Collections;

public class MySingletonManager : MonoBehaviour
{
    // Static singleton property
    public static MySingletonManager Instance
    {
        get; private set;
    }

    // public property for manager
    public string MyTestProperty = "Hello World";

    void Awake ()
    {
        if (Instance != null && Instance != this)
        {
            // Destroy other instances if they are not the same
            Destroy(gameObject);
        }
        // Save our current singleton instance
        Instance = this;

        // Make syure that the instance is not destroyed
        // between scenes ( this is optional )
        DontDestroyOnLoad(gameObject);
    }

    // public method for manager
    public void DoSomethingAwesome()
    {
        // the cool stuff happens here
    }
}
