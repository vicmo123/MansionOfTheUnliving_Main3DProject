using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Initialize();
    }

    private void Start()
    {
        GameManager.Instance.SecondInitialize();
    }

    private void Update()
    {
        GameManager.Instance.Refresh();
    }

    private void FixedUpdate()
    {
        GameManager.Instance.PhysicsRefresh();
    }
}
