using UnityEngine;

public class MessagingClientReciver : MonoBehaviour
{
    void Start()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }

    void ThePlayerisTryingToLeave()
    {
        Debug.Log("Oi Don't Leave me!! - " + tag.ToString());
    }