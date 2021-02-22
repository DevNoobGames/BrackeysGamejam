using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void StartAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void FollowDevNoob()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCz_DYtZNhmlyVDDKKy1dJ3g");
    }
}
