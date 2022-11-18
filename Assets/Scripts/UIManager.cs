using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
            return instance;
        }
    }

    private UIManager() { }
    #endregion

    public static UILinks UiLinks { get; set; }

    public void Initialize()
    {
        UiLinks = GameObject.FindGameObjectWithTag("UI").GetComponent<UILinks>();
    }

    public void SecondInitialize()
    {

    }

    public void Refresh()
    {
        UpdateAimPos();
    }

    public void PhysicsRefresh()
    {

    }

    private void UpdateAimPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        //Vector3 worldSpace = Camera.main.ScreenToWorldPoint(mousePos);

        UIManager.UiLinks.aim.transform.position = mousePos;
    }
}
