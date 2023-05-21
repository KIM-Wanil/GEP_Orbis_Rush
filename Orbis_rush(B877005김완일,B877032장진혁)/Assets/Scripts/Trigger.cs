using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] GameObject Wall;
    GravityItem gravityItem;

    private void Awake()
    {
        gravityItem = GameObject.Find("Player").GetComponent<GravityItem>(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(Wall);
        }
    }
}
