using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float interval;
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(obstaclePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}