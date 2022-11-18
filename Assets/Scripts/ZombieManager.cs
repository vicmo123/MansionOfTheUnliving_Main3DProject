using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager
{
    #region Singleton
    private static ZombieManager instance;
    public static ZombieManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ZombieManager();
            return instance;
        }
    }

    private ZombieManager() { }
    #endregion

    readonly float NUMBER_ZOMBIES_START = 2;
    readonly float NUMBER_SPECIAL_ZOMBIES = 1;
    readonly float ADDITIONAL_ZOMBIE = 1;

    private float totalZombies;

    private List<GameObject> tabZombie;
    private GameObject zombiePrefab;
    private GameObject specialZombiePrefab;

    static SpawnSpotsLinks spawnLocs;
    private float offSet = 10f;

    private int spawnCount;

    public int waveNumber { get; set; }
    public void Initialize()
    {
        waveNumber = 0;

        tabZombie = new List<GameObject>();

        zombiePrefab = Resources.Load<GameObject>("Prefabs/MaleZombie");
        specialZombiePrefab = Resources.Load<GameObject>("Prefabs/RumbaJim");

        spawnLocs = GameObject.FindGameObjectWithTag("SpawnPoints").gameObject.GetComponent<SpawnSpotsLinks>();
    } 

    public void SecondInitialize()
    {

    }

    public void WaveInitialize(Transform playerCurrentPos)
    {
        spawnCount = 0;

        SetupWave();
        SetTargetNavMesh(playerCurrentPos);
    }


    public void Refresh()
    {

    }
    public void PhysicsRefresh()
    {

    }

    private void SetupWave()
    {
        totalZombies = NUMBER_ZOMBIES_START + NUMBER_SPECIAL_ZOMBIES + (ADDITIONAL_ZOMBIE * waveNumber);

        for (int i = 0; i < totalZombies; i++)
        {
            GameObject zombie;

            if(i == 0)
            {
                zombie = GameObject.Instantiate(specialZombiePrefab);
            }
            else
            {
                zombie = GameObject.Instantiate(zombiePrefab);
            }

            var randomPos = spawnLocs.tabSpots[waveNumber].position + (Vector3)Random.insideUnitCircle * offSet;
            zombie.transform.position = randomPos;

            tabZombie.Add(zombie);

            spawnCount++;
        }
    }

    public void SetTargetNavMesh(Transform target)
    {
        foreach (GameObject Zombie in tabZombie)
        {
            ZombieAgentScript zas = Zombie.GetComponent<ZombieAgentScript>();
            zas.SetTarget(target);
        }
    }
}
