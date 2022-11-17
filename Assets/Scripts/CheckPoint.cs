using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public static UnityEvent<GameObject> PlayerReachedCheckPointEvent;

    private void Awake()
    {
        PlayerReachedCheckPointEvent = new UnityEvent<GameObject>();
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            PlayerReachedCheckPointEvent.Invoke(this.gameObject);
        }
    }
}
