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

    public int numOfCheckPoints;
    int current = 0;
    public float speed;
    float WPradius = 1;

    public void Initialize()
    {
        checkPoints = new GameObject[numOfCheckPoints];

        CheckPoint.PlayerReachedCheckPointEvent.AddListener(PlayerReachedCheckPoint);
    }

    public void SecondInitialize()
    {
        player = GameObject.FindWithTag("Player");

        GameObject tempCheckPoints = GameObject.FindWithTag("CheckPoints");

        for (int i = 0; i < numOfCheckPoints; i++)
        {
            checkPoints[i] = tempCheckPoints.transform.GetChild(i).gameObject;
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
        //transform.position = Vector3.MoveTowards(transform.position, checkPoints[current].transform.position, Time.deltaTime * speed);
    }

    private void PlayerReachedCheckPoint(GameObject triggeredCheckPoint)
    {
        player.transform.position = triggeredCheckPoint.transform.position;
        player.transform.rotation = triggeredCheckPoint.transform.rotation;
    }
}
