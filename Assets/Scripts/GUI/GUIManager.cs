using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField]
    private List<Menu> menus = new List<Menu>();

    private void Start()
    {
        closeAll();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeAll();
        }

        foreach (Menu menu in menus)
        {
            if (Input.GetKeyDown(menu.keyCode))
            {
                closeAll();
                if (!menu.menuGameObject.activeSelf)
                    menu.menuGameObject.SetActive(true);
            }
        }
    }

    private void closeAll()
    {
        foreach (Menu menu in menus)
        {
            menu.menuGameObject.SetActive(false);
        }
    }


    [Serializable]
    class Menu
    {
        public GameObject menuGameObject;
        public KeyCode keyCode;
    }
}
