using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform cameraRig;
    [SerializeField] float dist;

    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    [SerializeField] float yMinLimit;
    [SerializeField] float yMaxLimit;

    private float x;
    private float y;
    private Vector2 lookInput, screenCenter, mouseDistance;

    float temp_dist;
    Player player;

    void Start()
    {
        x = target.rotation.x;
        y = target.rotation.y;

        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;

        player = GameObject.Find("Player").GetComponent<Player>();
        temp_dist = dist;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (target)
        {
            lookInput.x = Input.mousePosition.x;
            lookInput.y = Input.mousePosition.y;


            mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;

            mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

            mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

            if (!player.puzzle1_is_start)
            {
                dist = temp_dist;
                if (dist >= temp_dist)
                {
                    dist = temp_dist;
                }
            }

            else if (player.puzzle1_is_start)
            {
                dist = 9f;
                if (dist >= 9f)
                {
                    dist = 9f;
                }
            }

            if (mouseDistance.x > 0.3 || mouseDistance.x < -0.3)
                x += mouseDistance.x * xSpeed * 0.02f;
            else if ((mouseDistance.y > 0.4 || mouseDistance.y < -0.4))
                y -= mouseDistance.y * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0f, 0f, -dist) + target.position + new Vector3(0f, 0f, 0f);

            if (!player.puzzle1_is_start)
            {
                position.y += 2f;
            }

            else if (player.puzzle1_is_start)
            {
                position.y += 3.5f;
            }

            transform.rotation = rotation;
            transform.position = position;

        }

      
        else
            dist = 5f;
    }

    float ClampAngle(float anlge, float min, float max)
    {
        if (anlge < -360f)
            anlge += 360f;
        if (anlge > 360f)
            anlge -= 360f;

        return Mathf.Clamp(anlge, min, max);
    }

}
