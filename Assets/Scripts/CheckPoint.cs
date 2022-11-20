using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static UnityEvent PlayerReachedCheckPointEvent;

    int count = 0;
    private void Awake()
    {
        PlayerReachedCheckPointEvent = new UnityEvent();
    }

    void OnTriggerEnter(Collider plyr)
    {
        count++;
        
        if (plyr.gameObject.tag == "Player" || count != 2 || count != 4)
        {
            PlayerReachedCheckPointEvent.Invoke();
        }
    }
}
