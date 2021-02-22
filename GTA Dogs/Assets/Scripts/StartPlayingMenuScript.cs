using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayingMenuScript : MonoBehaviour
{
    public GameObject inGameUI;

    public void Start()
    {
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        inGameUI.SetActive(true);
        this.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
