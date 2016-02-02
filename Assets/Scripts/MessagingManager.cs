using System;
using System.Collections.Generic;
using UnityEngine;

public class MessagingManager: MonoBehaviour
{
    // Static singleton property
    public static MessagingManager Instance { get; private set;}

    // puiblic property for manager
    private List<Action> subscribers = new List<Action>();

    void Awake()
    {
        Debug.Log("Messaging Manager Started");
        // First we check if there are any other instances conflicting 
        if ( Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        // save out singleton instance
        Instance = this;

        //Make sure that this instance is not destroyed
        // during scene transition ( this is optional )
        DontDestroyOnLoad(gameObject);
    }

    // tyhe Subscribe method for the manager
    public void Subscribe( Action subscriber)
    {
        Debug.Log("Subscriber registered");
        subscribers.Add(subscriber);
    }

    // The Unsubscribe method for the manager
    public void UnSuubscribe(Action subscriber)
    {
        Debug.Log("Subscriber registered");
        subscribers.Remove(subscriber);
    }

    // Clear subscribers method for manager
    public void ClearAllSubscribers()
    {
        subscribers.Clear();
    }

    public void Broadcast()
    {
        Debug.Log("Broadcast requested , No of Subscribers = " + subscribers.Count);
        foreach (var subscriber in subscribers)
        {
            subscriber();
        }
    }
}

