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

    enum GamePhase
    {
        MainMenu,
        Setup,
        Attack, 
        Move
    }

    GamePhase gamephase;

    // Start is called before the first frame update
    public void Initialize()
    {
        gamephase = GamePhase.Move;

        CheckPoint.PlayerReachedCheckPointEvent.AddListener(PlayerArrivedAtDestination);

        UIManager.Instance.Initialize();
        PlayerManager.Instance.Initialize();
        CheckPointsManager.Instance.Initialize();
        ZombieManager.Instance.Initialize();
    }

    public void SecondInitialize()
    {
        UIManager.Instance.SecondInitialize();
        PlayerManager.Instance.SecondInitialize();
        CheckPointsManager.Instance.SecondInitialize();
        ZombieManager.Instance.SecondInitialize();
    }

    public void Refresh()
    {
        switch (gamephase)
        {
            case GamePhase.Setup:
                SetupUpdate();
                break;
            case GamePhase.Attack:
                AttackUpdate();
                break;
            case GamePhase.Move:
                MovingUpdate();
                break;
            default:
                Debug.Log("unhandeled case " + gamephase);
                break;
        }

        CheckPointsManager.Instance.Refresh();
        UIManager.Instance.Refresh();
    }

    public void PhysicsRefresh()
    {

    }

    private void SetupUpdate()
    {
        ZombieManager.Instance.WaveInitialize(PlayerManager.Instance.player.transform);

        Debug.Log("Setup");

        gamephase = GamePhase.Attack;
    }

    private void AttackUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gamephase = GamePhase.Move;
        }
    }

    private void MovingUpdate()
    {
        PlayerManager.Instance.canMove = true;

        PlayerManager.Instance.MoveToNextCheckPoint(CheckPointsManager.Instance.GetDestination());
    }

    private void PlayerArrivedAtDestination()
    {
        gamephase = GamePhase.Setup;

        Debug.Log("Hey");
        CheckPointsManager.Instance.SetCurrent();
    }
}
