using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int Health = 3;
    public GameObject Centipede;
    public bool Attackable;
    public bool CouroRunning;
    public TextMeshProUGUI BodyPartsText;
    public int PartsFound;
    public List<GameObject> Hearts;

    public float Timer;
    public bool RunTimer;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI TimerTextWin;

    public GameObject MenuCam;
    public GameObject LostMenu;
    public GameObject WinMenu;
    public GameObject InGameUI;

    public GameObject InjuredPanel;
    public AudioSource InjuredAudio;

    private void Start()
    {
        BodyPartsText.text = "0/10";
        PartsFound = 0;

        RunTimer = true;
        Timer = 0;
    }

    void Update()
    {
        if (RunTimer)
        {
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.RoundToInt(Timer % 60);
            TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        if (Health <= 0)
        {
            MenuCam.SetActive(true);
            LostMenu.SetActive(true);
            InGameUI.SetActive(false);
            this.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Destroy(Centipede);
        }

        if (Attackable == false && CouroRunning == false)
        {
            CouroRunning = true;
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(ResetAttack());
            }
        }

        if (PartsFound >= 10)
        {
            this.gameObject.SetActive(false);
            MenuCam.SetActive(true);
            WinMenu.SetActive(true);
            InGameUI.SetActive(false);
            InjuredPanel.SetActive(false);
            RunTimer = false;
            int minutes = Mathf.FloorToInt(Timer / 60);
            int seconds = Mathf.RoundToInt(Timer % 60);
            TimerTextWin.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdatePartsText()
    {
        BodyPartsText.text = PartsFound + "/10";
    }

    public void UpdateHearts()
    {
        if (Hearts.Count > 0)
        {
            Hearts[0].SetActive(false);
            Hearts.RemoveAt(0);
        }
    }

    public IEnumerator Injured()
    {
        InjuredPanel.SetActive(false);
        InjuredPanel.SetActive(true);
        InjuredAudio.Play();
        yield return new WaitForSeconds(0.9f);
        InjuredPanel.SetActive(false);
    }

    public IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1);
        Attackable = true;
        CouroRunning = false;
    }
}
