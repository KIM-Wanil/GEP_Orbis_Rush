using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityItem : MonoBehaviour
{
    public bool is_get_upgravity;
    public bool is_get_downgravity;
    [SerializeField] GameObject[] gravityitem;

    [SerializeField] float downgravity;
    [SerializeField] float upgravity;

    Rigidbody rigid;
    Player player;

    float time;
    int duration;

    public Image gravity;

    public Image itemGauge;
    public Image upIcon;
    public Image downIcon;

    public AudioClip audioItem;
    AudioSource audioSource;

    void Awake()
    {
        is_get_upgravity = false;
        is_get_downgravity = false;
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();

        duration = 7;
        this.audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        if (is_get_upgravity)
        {
            rigid.AddForce(Vector3.down * upgravity);
        }

        if (is_get_downgravity && player.is_jump)
        {
            rigid.AddForce(Vector3.up * downgravity);
        }
    }

    void Update()
    {
        if(is_get_upgravity)
        {
            time += Time.deltaTime;
            itemGauge.fillAmount = (duration - time) / duration;
            Debug.Log((int)time);
            if(duration <= (int)time || player.is_check==true)
            {
                gravity.fillAmount -= upgravity * 0.05f;
                player.is_check = false;
                player.is_jump = false;
                is_get_upgravity = false;
                time = 0;

                itemGauge.fillAmount = 1.0f;
                upIcon.gameObject.SetActive(false);
                itemGauge.gameObject.SetActive(false);
            }
        }

        else if (is_get_downgravity)
        {
            time += Time.deltaTime;
            itemGauge.fillAmount = (duration - time) / duration;
            if (duration <= (int)time || player.is_check == true)
            {
                gravity.fillAmount += downgravity * 0.05f;
                player.is_check = false;
                is_get_downgravity = false;
                time = 0;

                itemGauge.fillAmount = 1.0f;
                downIcon.gameObject.SetActive(false);
                itemGauge.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GravityItem1"))
        {
            is_get_downgravity = true;
            gravity.fillAmount -= downgravity * 0.05f;
            gravityitem[0].SetActive(false);

            downIcon.gameObject.SetActive(true);
            itemGauge.gameObject.SetActive(true);

            audioSource.clip = audioItem;
            audioSource.Play();
        }

        if (other.gameObject.CompareTag("GravityItem2"))
        {
            gravity.fillAmount -= downgravity * 0.05f;
            is_get_downgravity = true;
            gravityitem[1].SetActive(false);

            downIcon.gameObject.SetActive(true);
            itemGauge.gameObject.SetActive(true);

            audioSource.clip = audioItem;
            audioSource.Play();
        }
    }
}
