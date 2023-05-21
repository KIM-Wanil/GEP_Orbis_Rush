using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject MenuPanel;
    AudioSource audioSource;
    public AudioClip audioClick;
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }
    public void Menu_button()
    {
        Time.timeScale = 0; //게임 일시정지
        MenuPanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
    public void LoadTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
    public void LoadFailStage1()
    {
        SceneManager.LoadScene("Fail_Stage1");
    }
    public void LoadFailStage2()
    {
        SceneManager.LoadScene("Fail_Stage2");
    }
    public void click_sound()
    {
        audioSource.clip = audioClick;
        audioSource.Play();
    }
}

