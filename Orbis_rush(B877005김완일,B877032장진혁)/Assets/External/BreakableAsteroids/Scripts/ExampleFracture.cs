using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleFracture : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject chonker;
    private int counter = 0;

    void Update()
    {
        //Code loops through asteroids and fractures them on space
        if (Input.GetKeyDown(KeyCode.Z))
        {
            asteroids[counter].GetComponent<Fracture>().FractureObject();
            counter++;
        }
        if (Input.GetKey(KeyCode.I))
        {
            chonker.gameObject.SetActive(true);
        }

    }
}
