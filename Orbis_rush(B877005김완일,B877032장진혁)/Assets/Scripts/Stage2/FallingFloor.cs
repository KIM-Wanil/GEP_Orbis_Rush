using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloor : MonoBehaviour
{
    Player_st2 player;
    bool is_step;
    float time;
    float delay;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_st2>();
        is_step = false;
        delay = 1.5f;
    }

    private void Update()
    {
        if(is_step)
        {
            time += Time.deltaTime;
            if (delay <= time)
            {
                gameObject.SetActive(false);
                is_step = false;
                time = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            is_step = true;
        }
    }
}
