using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    #region Singleton
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
                instance = new SoundManager();
            return instance;
        }
    }

    private SoundManager() { }
    #endregion

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
