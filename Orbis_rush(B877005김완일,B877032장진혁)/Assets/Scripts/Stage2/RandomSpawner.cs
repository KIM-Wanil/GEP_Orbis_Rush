using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    float random_num;
    float time;
    int delay;

    private void Start()
    {
        delay = 2;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(delay <= (int)time)
        {
            random_num = Random.Range(0, 20);
            Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, transform.position.z + random_num), transform.rotation);
            time = 0;
        }

    }
}
