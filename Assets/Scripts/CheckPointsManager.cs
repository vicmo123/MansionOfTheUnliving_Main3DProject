using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager
{
    #region Singleton
    private static CheckPointsManager instance;
    public static CheckPointsManager Instance
    {
        get
        {
            if (instance == null)
                instance = new CheckPointsManager();
            return instance;
        }
    }

    private CheckPointsManager() { }
    #endregion

    private GameObject[] checkPoints;
    private GameObject player;

    public int numOfCheckPoints = 9;
    public int current { get; set; }

    public void Initialize()
    {
        checkPoints = new GameObject[numOfCheckPoints];

        current = -1;
    }

    public void SecondInitialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject checkPointParent = GameObject.FindGameObjectWithTag("CheckPoints");

        for (int i = 0; i < numOfCheckPoints; i++)
        {
            checkPoints[i] = checkPointParent.transform.GetChild(i).gameObject;
        }
    }

    public void Refresh()
    {
        //if (Vector3.Distance(checkPoints[current].transform.position, transform.position) < WPradius)
        //{
        //    current = Random.Range(0, checkPoints.Length);
        //    if (current >= checkPoints.Length)
        //    {
        //        current = 0;
        //    }
        //}
        Debug.Log(checkPoints.Length);
        
    }

    public Transform GetDestination()
    {
        if(current + 1 < checkPoints.Length)
        {
            return checkPoints[current + 1].transform;
        }
        else
        {
            return checkPoints[current].transform;
        }
    }

    public void SetCurrent()
    {
        if (current < numOfCheckPoints)
        {
            current++;
        }
    }
}
