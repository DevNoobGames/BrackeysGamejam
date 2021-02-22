using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    public GameObject IntroSubtitles;
    public GameObject IntroStarter;
    public GameObject MenuCam;

    public GameObject CreditMenu;

    public void startgame()
    {
        IntroSubtitles.SetActive(true);
        IntroStarter.SetActive(true);
        MenuCam.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Credits()
    {
        if (CreditMenu.activeInHierarchy)
        {
            CreditMenu.SetActive(false);
        }
        else
        {
            CreditMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FollowDevNoob()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCz_DYtZNhmlyVDDKKy1dJ3g");
    }
}
