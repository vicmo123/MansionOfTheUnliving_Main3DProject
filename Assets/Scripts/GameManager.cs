using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    bool startGame = false;

    // Start is called before the first frame update
    public void Initialize()
    {
        gamephase = GamePhase.MainMenu;

        CheckPoint.PlayerReachedCheckPointEvent.AddListener(PlayerArrivedAtDestination);

        UIManager.Instance.Initialize();
        PlayerManager.Instance.Initialize();
        CheckPointsManager.Instance.Initialize();
        ZombieManager.Instance.Initialize();
        SoundManager.Instance.Initialize();
    }

    public void SecondInitialize()
    {
        UIManager.Instance.SecondInitialize();
        PlayerManager.Instance.SecondInitialize();
        CheckPointsManager.Instance.SecondInitialize();
        ZombieManager.Instance.SecondInitialize();
        SoundManager.Instance.SecondInitialize();

        UIManager.Instance.mainMenuButton.onClick.AddListener(StartGame);
    }

    public void Refresh()
    {
        switch (gamephase)
        {
            case GamePhase.MainMenu:
                MainMenuUpdate();
                break;
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


    public void MainMenuUpdate()
    {
        if (startGame)
        {
            UIManager.UiLinks.mainMenu.SetActive(false);
            UIManager.UiLinks.playerStatsUI.SetActive(true);

            gamephase = GamePhase.Move;

            SoundManager.Instance.PlayRumbaMusic();
        }
    }

    private void SetupUpdate()
    {
        ZombieManager.Instance.WaveInitialize(PlayerManager.Instance.player.transform);

        Debug.Log("Setup");

        gamephase = GamePhase.Attack;
    }

    private void AttackUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerManager.Instance.ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.Space) || ZombieManager.Instance.CheckIfWaveIsOver() == true)
        {
            gamephase = GamePhase.Move;

            if(ZombieManager.Instance.waveNumber < ZombieManager.Instance.numLocs)
            {
                ZombieManager.Instance.waveNumber++;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
            }
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

        CheckPointsManager.Instance.SetCurrent();
    }

    public void StartGame()
    {
        startGame = true;
    }
}
