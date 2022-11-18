using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    #region Singleton
    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerManager();
            return instance;
        }
    }

    private PlayerManager() { }
    #endregion

    public GameObject player { get; set; }

    public bool canMove;
    public float smoothSpeed = 0.007f;
    public Vector3 locationOffset;
    public Vector3 rotationOffset;

    public void Initialize()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        canMove = false;
    }

    public void SecondInitialize()
    {

    }

    public void Refresh()
    {
        
    }

    public void MoveToNextCheckPoint(Transform destination)
    {
        if (canMove)
        {
            //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(destination.position.x, player.transform.position.y, destination.position.z), Time.deltaTime * speed);

            Vector3 desiredPosition = destination.position + destination.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(player.transform.position, desiredPosition, smoothSpeed);
            player.transform.position = smoothedPosition;

            Quaternion desiredrotation = destination.rotation * Quaternion.Euler(rotationOffset);
            Quaternion smoothedrotation = Quaternion.Lerp(player.transform.rotation, desiredrotation, smoothSpeed);
            player.transform.rotation = smoothedrotation;
        }

    }
}
