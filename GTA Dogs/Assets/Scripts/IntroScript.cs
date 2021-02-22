using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroScript : MonoBehaviour
{
    public GameObject ExplodingCentipede;
    public GameObject SyringeDude;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public TextMeshProUGUI Subtitles;
    public GameObject SubtitlePanel;
    public AudioSource IntroMusic;
    public AudioSource BackgroundMusic;
    public AudioSource PopSound;

    [Header("Start Game Settings")]
    public GameObject StartUIPanel;
    public GameObject PlayerCentipede;

    public 
    
    void Start()
    {
        StartCoroutine(SequenceRunner());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            skipIntro();
        }
    }

    void skipIntro()
    {
        StopAllCoroutines();
        Cam1.SetActive(false);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        SubtitlePanel.SetActive(false);
        PlayerCentipede.SetActive(true);
        Destroy(ExplodingCentipede);
        StartUIPanel.SetActive(true);
        IntroMusic.Stop();
        BackgroundMusic.Play();
        Destroy(gameObject);
    }

    IEnumerator SequenceRunner()
    {
        Cam1.SetActive(true);
        Subtitles.text = "Let's expirement on this caterpillar!";
        yield return new WaitForSeconds(4.5f);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        Subtitles.text = "Here we go!";
        SyringeDude.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        Subtitles.text = "Oh no!!! What's happening!?";
        ExplodingCentipede.GetComponent<Animator>().enabled = true;
        //IntroMusic.Stop();
        yield return new WaitForSeconds(1.1f);
        //IntroMusic.Stop();
        yield return new WaitForSeconds(0.4f);
        IntroMusic.Stop();
        PopSound.Play();
        //yield return new WaitForSeconds(1.75f);
        yield return new WaitForSeconds(0.25f);
        Destroy(ExplodingCentipede);
        yield return new WaitForSeconds(3);
        Cam3.SetActive(false);
        SubtitlePanel.SetActive(false);
        PlayerCentipede.SetActive(true);
        StartUIPanel.SetActive(true);
        BackgroundMusic.Play();
        Destroy(gameObject);
    }
}
