using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animCtrl;
    public ZombieAgentScript agentScript;
    float time = 0.0f;
    float timeBetweenZombieSound = 3f;

    bool isDead = false;
   
    public float healthPoints { get; set; }

    private void Start()
    {
        healthPoints = 2;
    }

    private void Update()
    {
        CheckIfDead();
        CheckIfInRange();

        time += Time.deltaTime;

        if (time >= timeBetweenZombieSound)
        {
            time = 0.0f;

            SoundManager.Instance.PlayZombieSound();
        }
    }

    public void CheckIfDead()
    {
        if(healthPoints <= 0.0 && isDead == false)
        {
            animCtrl.SetTrigger("IsDead");

            agentScript.followTarget = null;

            isDead = true;

            ZombieManager.Instance.spawnCount--;
        }
    }

    public void GetShotByPlayer(float dmg)
    {
        healthPoints -= dmg;

        SoundManager.Instance.PlayZombieHurtSound();
        SoundManager.Instance.StopZombieSound();
    }

    private void CheckIfInRange()
    {
        Debug.Log((agentScript.followTarget.position - this.gameObject.transform.position).magnitude);

        if((agentScript.followTarget.position - this.gameObject.transform.position).magnitude < 8f)
        {
            animCtrl.SetBool("IsInRange", true);
        }
    }
}
