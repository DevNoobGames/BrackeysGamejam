using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    public void QuitGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
