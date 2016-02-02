using UnityEngine;

public class MessagingClientReciver: MonoBehaviour
{
    void Start()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }

    void ThePlayerIsTryingToLeave()
    {
        Debug.Log("Oi Don't Leave me!! - " + tag.ToString());
    }
}