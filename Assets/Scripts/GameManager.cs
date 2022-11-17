using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    private GameManager() { }
    #endregion

    // Start is called before the first frame update
    public void Initialize()
    {
        
    }

    public void SecondInitialize()
    {

    }

    public void Refresh()
    {
        
    }

    public void PhysicsRefresh()
    {

    }
}
