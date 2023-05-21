using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRespawn : MonoBehaviour
{
    Player_st2 player;
    Trigger_st2 trigger;
    Snowball snowball;
    [SerializeField] GameObject[] fallingfloor;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject trigger_obj;

    bool is_respawn;
    bool is_dest;
    Vector3 snowball_startPos;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_st2>();
        trigger = GameObject.Find("Trigger1").GetComponent<Trigger_st2>();
        snowball = GameObject.Find("SnowBall").GetComponent<Snowball>();
        is_respawn = false;
        snowball_startPos = snowball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.is_hit)
        {
            is_respawn = true;
            trigger.is_destroyed = false;
        }

        if (is_respawn)
        {
            for (int i = 0; i < fallingfloor.Length; i++)
                fallingfloor[i].SetActive(true);

            if(!player.puzzle1_end)
            {
                snowball.gameObject.SetActive(true);
                trigger_obj.SetActive(true);
                wall.SetActive(true);
                snowball.transform.position = snowball_startPos;
                snowball.rigid.constraints = RigidbodyConstraints.FreezeRotation;
            }

            is_respawn = false;
        }

        if (trigger.is_destroyed)
        {
            if(player.puzzle1_end)
                wall.SetActive(false);
            snowball.gameObject.SetActive(false);
            trigger_obj.SetActive(false);
        }
    }
}
