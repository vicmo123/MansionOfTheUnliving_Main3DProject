using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static UnityEvent PlayerReachedCheckPointEvent;

    private void Awake()
    {
        PlayerReachedCheckPointEvent = new UnityEvent();
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            PlayerReachedCheckPointEvent.Invoke();
        }
    }
}
