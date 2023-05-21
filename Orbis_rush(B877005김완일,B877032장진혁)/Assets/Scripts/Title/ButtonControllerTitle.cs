using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerTitle : MonoBehaviour
{
    public GameObject infoCanvas;
    AudioSource audioSource;
    public AudioClip audioClick;
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Info_button()
    {
        infoCanvas.SetActive(true);
    }
    public void Back_button()
    {
        infoCanvas.SetActive(false);
    }
    public void click_sound()
    {
        audioSource.clip = audioClick;
        audioSource.Play();
    }
}
