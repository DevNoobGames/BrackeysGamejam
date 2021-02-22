using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinuePlaying();
        }
    }

    public void ContinuePlaying()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
