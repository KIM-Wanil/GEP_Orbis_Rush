using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookInStation : MonoBehaviour
{
    public Transform player;

    public float MouseSensitivity = 10;

    float x = 0;
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

        x += -Input.GetAxis("Mouse Y") * MouseSensitivity;
        y += Input.GetAxis("Mouse X") * MouseSensitivity;

        x = Mathf.Clamp(x, -90, 90);

        //transform.localRotation = Quaternion.Euler(x, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, y, 0);
        Cursor.lockState = CursorLockMode.Confined;
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (Cursor.lockState == CursorLockMode.Locked)
        //        Cursor.lockState = CursorLockMode.None;
        //}

    }
}
