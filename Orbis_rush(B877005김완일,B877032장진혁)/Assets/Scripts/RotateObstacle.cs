using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    int dir = 1;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, Time.deltaTime*60.0f);

        if (transform.localPosition.z < -1.0f)
        {
            dir = 1;
        }
        else if (transform.localPosition.z > 1.0f)
        {
            dir = -1;
        }
        transform.Translate(new Vector3(0, 0, 1.0f) * speed * Time.deltaTime * dir);
    }
}
