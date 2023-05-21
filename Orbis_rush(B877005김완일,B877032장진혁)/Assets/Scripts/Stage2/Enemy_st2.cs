using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_st2 : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float follow_speed;

    NavMeshAgent nav;
    Animator anim;
    int count;

    Player_st2 player;

    void Start()
    {
        count = 0;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player").GetComponent<Player_st2>();
        nav.SetDestination(waypoints[0].position);
        anim.SetFloat("speed", nav.speed);
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        detect_player();
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[count].position) < 1)
        {
            anim.SetFloat("speed", nav.speed);
            if (count < waypoints.Length - 1)
            {
                count++;
                nav.SetDestination(waypoints[count].position);
            }

            else if (count == waypoints.Length - 1)
            {
                count = 0;
                nav.SetDestination(waypoints[0].position);
            }
        }
    }

    void detect_player()
    {
        var colliders = Physics.OverlapSphere(transform.position, distance, layerMask);


        foreach (var collider in colliders)
        {
            //�ݶ��̴��� �±װ� �÷��̾ �ƴϸ� ��ŵ
            if (!collider.CompareTag("Player"))
            {
                continue;
            }

            else
            {
                anim.SetFloat("speed", follow_speed);
                //�÷��̾�� �ڽ��� ���� ���� ���ϱ�
                Vector3 dir = (collider.transform.position - transform.position).normalized;

                //y���ʹ� �ʿ� ������ 0���� ��ȯ�� ���� ����
                dir = new Vector3(dir.x, 0, dir.z);

                transform.position += dir * follow_speed * Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 3f);
            }
        }
    }
}
