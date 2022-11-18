using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager
{
    readonly float NUMBER_ZOMBIES_START = 2;
    readonly float NUMBER_SPECIAL_ZOMBIES = 1;
    readonly float ADDITIONAL_ZOMBIE = 1;

    private float totalZombies;

    private List<GameObject> tabZombie;
    private GameObject zombiePrefab;
    private GameObject specialZombiePrefab;

    static SpawnSpotsLinks spawnLocs;
    private float offSet = 10f;

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

    public void Initialize()
    {

        tabZombie = new List<GameObject>();

        zombiePrefab = Resources.Load<GameObject>("Prefabs/MaleZombie");
        specialZombiePrefab = Resources.Load<GameObject>("Prefabs/RumbaJim");
    }

    public void SecondInitialize()
    {

    }

    public void SetupWave(int waveNumber)
    {
        totalZombies = NUMBER_ZOMBIES_START + NUMBER_SPECIAL_ZOMBIES + (ADDITIONAL_ZOMBIE * waveNumber);

        for (int i = 0; i < totalZombies; i++)
        {
            if(i == 0)
            {
                tabZombie[i] = GameObject.Instantiate(specialZombiePrefab);
            }
            else
            {
                tabZombie[i] = GameObject.Instantiate(zombiePrefab);
            }

            var randomPos = spawnLocs.tabSpots[waveNumber].position + (Vector3)Random.insideUnitCircle * 10;
            tabZombie[i].transform.position = randomPos;

            
            //SpawnCount++;
        }
    }

    public void Refresh()
    {

    }

    public void PhysicsRefresh()
    {

    }
}
