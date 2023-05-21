using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_st2 : MonoBehaviour
{
    public bool is_destroyed;

    private void Start()
    {
        is_destroyed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("SnowBall"))
        {
            is_destroyed = true;
        }
    }
}
