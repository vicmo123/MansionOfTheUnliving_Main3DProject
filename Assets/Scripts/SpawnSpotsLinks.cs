using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpotsLinks : MonoBehaviour
{
    public Transform spot1;
    public Transform spot2;
    public Transform spot3;
    public Transform spot4;
    public Transform spot5;

    private int numSpots = 5;
    public Transform[] tabSpots { get; set; }

    private void Awake()
    {
        tabSpots = new Transform[numSpots];
    }
}
