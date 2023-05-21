using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void LoadMain()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void LoadInfo()
    {
        SceneManager.LoadScene("Info");
    }
}
