using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowSpawner : MonoBehaviour
{
    [SerializeField] Transform player;
    public GameObject obstaclePrefab;
    public float interval;
    float time;
    float delay;

    private void Awake()
    {
        delay = 2.85f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (delay <= time)
        {
            time = 0;
            GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(player.transform.position.x, player.transform.position.y + 10f, player.transform.position.z), transform.rotation);
        }

    }
}