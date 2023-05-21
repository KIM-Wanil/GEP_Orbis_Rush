using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject save1;
    public GameObject save2;
    public bool isSave1;
    public bool isSave2;

    AudioSource audioSource;
    public AudioClip audioSave;
    private void Start()
    {
        isSave1 = false;
        isSave2 = false;
        this.audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Save1"))
        {
            if (!isSave1)
            {
                Debug.Log("save1 work");
                isSave1 = true;
                isSave2 = false;

                audioSource.clip = audioSave;
                audioSource.Play();
            }
        }

        if (other.gameObject.CompareTag("Save2"))
        {
            if (!isSave2)
            {
                Debug.Log("save2 work");
                isSave2 = true;
                isSave1 = false;

                audioSource.clip = audioSave;
                audioSource.Play();
            }
        }
    }
}
