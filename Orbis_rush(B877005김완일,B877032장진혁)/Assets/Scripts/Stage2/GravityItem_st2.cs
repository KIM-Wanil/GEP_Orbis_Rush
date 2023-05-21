using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityItem_st2 : MonoBehaviour
{
    public bool is_get_item1;
    public bool is_get_item2;
    [SerializeField] GameObject[] gravityitem;

    [SerializeField] float downgravity1;
    [SerializeField] float downgravity2;

    Rigidbody rigid;
    Player_st2 player;

    float time;
    [SerializeField] int duration;
    [SerializeField] int duration2;

    public Image gravity;

    public Image itemGauge;
    public Image upIcon;
    public Image downIcon;

    public AudioClip audioItem;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        is_get_item1 = false;
        is_get_item2 = false;
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player_st2>();

        this.audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (is_get_item1 && player.is_jump)
        {
            rigid.AddForce(Vector3.up * downgravity1);
            
        }

        else if(is_get_item2 && player.is_jump)
        {
            rigid.AddForce(Vector3.up * downgravity2);
            
        }
        
    }

    void Update()
    {

        if (player.is_hit == true)
            Debug.Log(player.is_hit);

        if (is_get_item1)
        {
            time += Time.deltaTime;
            itemGauge.fillAmount = (duration - time) / duration;
            if (duration <= (int)time || player.is_check == true)
            {
                
                time = 0;
                gravity.fillAmount += downgravity1 * 0.05f;
                is_get_item1 = false;

                player.is_check = false;
                itemGauge.fillAmount = 1.0f;
                downIcon.gameObject.SetActive(false);
                itemGauge.gameObject.SetActive(false);
            }
        }

        else if (is_get_item2)
        {
            
            time += Time.deltaTime;
            itemGauge.fillAmount = (duration2-time) / duration2;
            if (duration2 <= (int)time || player.is_check == true)
            {
                time = 0;
                gravity.fillAmount += downgravity2 * 0.05f;
                is_get_item2 = false;

                player.is_check = false;
                itemGauge.fillAmount = 1.0f;
                downIcon.gameObject.SetActive(false);
                itemGauge.gameObject.SetActive(false);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GravityItem1"))
        {
            is_get_item1 = true;

            downIcon.gameObject.SetActive(true);
            itemGauge.gameObject.SetActive(true);

            gravity.fillAmount -= downgravity1 * 0.05f;
            gravityitem[0].SetActive(false);

            audioSource.clip = audioItem;
            audioSource.Play();
        }

        if(other.gameObject.CompareTag("GravityItem2"))
        {
            is_get_item2 = true;

            downIcon.gameObject.SetActive(true);
            itemGauge.gameObject.SetActive(true);

            gravity.fillAmount -= downgravity2 * 0.05f;
            gravityitem[1].SetActive(false);

            audioSource.clip = audioItem;
            audioSource.Play();
        }
    }
}
