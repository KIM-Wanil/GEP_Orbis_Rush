using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCanvas : MonoBehaviour
{
    Player player;
    [SerializeField] Transform puzzle1startline;
    
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if(player.puzzle1_is_start)
        {
            transform.position = new Vector3(player.transform.position.x, puzzle1startline.transform.position.y, player.transform.position.z);
        }

    }
}
