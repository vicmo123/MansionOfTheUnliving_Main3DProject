using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Animator animCtrl;
    public ZombieAgentScript agentScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animCtrl.SetFloat("Speed", value: 1);

        Debug.Log(animCtrl.GetFloat("Speed"));


        Debug.Log(agentScript.agent.velocity);
    }
}
