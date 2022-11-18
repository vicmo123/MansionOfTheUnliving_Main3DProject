using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animCtrl;
    public ZombieAgentScript agentScript;

    public float healthPoints { get; set; }

    private void Start()
    {
        healthPoints = 2;
        animCtrl.SetFloat("Speed", value: 1);
    }

    private void Update()
    {
        checkIfDead();
    }

    public void checkIfDead()
    {
        if(healthPoints <= 0.0)
        {
            animCtrl.SetTrigger("IsDead");
        }
    }

    public void GetShotByPlayer(float dmg)
    {
        healthPoints -= dmg;
    }
}
