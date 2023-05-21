using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Animator anim;

    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] gravityitem;


    public bool is_jump;

    float h, v;
    Vector3 dir;

    GameObject cam;
    Rigidbody rigid;

    public bool puzzle1_is_start;

    SavePoint save_point;
    Vector3 startPos;
    public bool is_hit;
    public bool is_check;
    public int hp;
    bool o2_empty;

    public Image o2;

    public AudioClip audioJump;
    AudioSource audioSource;



    void Awake()
    {
        puzzle1_is_start = false;
        is_hit = false;
        is_jump = false;
        is_check = false;
        o2_empty = false;

        hp = 3;
        startPos = transform.position;

        anim = gameObject.GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        save_point = GetComponent<SavePoint>();
        cam = GameObject.Find("PlayerCamera");

        Physics.gravity = new Vector3(0, -5, 0);
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        if (puzzle1_is_start)
        {
            spawner.SetActive(true);
            panel.SetActive(true);
        }
        else if (puzzle1_is_start == false)
        {
            spawner.SetActive(false);
            panel.SetActive(false);
        }

        Move();
        Jump();
        Checkdamaged();
    }

    void Move()
    {
        Vector3 lookvector = transform.position - cam.transform.position;
        lookvector.y = 0;
        lookvector = lookvector.normalized;

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = lookvector * v * Time.deltaTime;
        dir += Quaternion.Euler(0, 90, 0) * lookvector * Time.deltaTime * h;
        dir = dir.normalized;

        Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
               transform.forward,
               dir,
               rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir)
           );
        transform.LookAt(transform.position + forward);

        transform.position += dir * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !is_jump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            audioSource.clip = audioJump;
            audioSource.Play();
            is_jump = true;
        }

    }

    void Checkdamaged()
    {
        if (hp == 0)
            SceneManager.LoadScene("Fail_Stage1");

        if (o2.fillAmount == 0)
            o2_empty = true;

        //Dead by O2 empty
        if (save_point.isSave1 && !save_point.isSave2 && o2_empty)
        {
            transform.position = save_point.save1.transform.position;
            o2.fillAmount = 1.0f;
            hp--;
            o2_empty = false;
        }

        else if (save_point.isSave2 && !save_point.isSave1 && o2_empty)
        {
            transform.position = save_point.save2.transform.position;
            o2.fillAmount = 1.0f;
            hp--;
            o2_empty = false;
        }

        else if (!save_point.isSave1 && !save_point.isSave2 && o2_empty)
        {
            transform.position = startPos;
            o2.fillAmount = 1.0f;
            hp--;
            o2_empty = false;
        }

        //Dead by Obstacle
        if (save_point.isSave1 && !save_point.isSave2 && is_hit)
        {
            transform.position = save_point.save1.transform.position;
            is_hit = false;
        }

        else if (save_point.isSave2 && !save_point.isSave1 && is_hit)
        {
            transform.position = save_point.save2.transform.position;
            is_hit = false;
        }

        else if (!save_point.isSave1 && !save_point.isSave2 && is_hit)
        {
            transform.position = startPos;
            is_hit = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_jump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puzzle1Start"))
        {
            puzzle1_is_start = true;
        }

        if (other.gameObject.CompareTag("Puzzle1End"))
        {
            puzzle1_is_start = false;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            is_hit = true;
            if (GetComponent<GravityItem>().is_get_downgravity ==true)
            {
                is_check = true;
            }
            puzzle1_is_start = false;
            hp--;
            o2.fillAmount = 1.0f;
            //죽어서 respawn시, item respawn
            for (int i = 0; i < gravityitem.Length; i++)
                gravityitem[i].SetActive(true);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            is_hit = true;
            if (GetComponent<GravityItem>().is_get_downgravity == true)
            {
                is_check = true;
            }
            puzzle1_is_start = false;
            hp--;
            o2.fillAmount = 1.0f;
            //죽어서 respawn시, item respawn
            for (int i = 0; i < gravityitem.Length; i++)
                gravityitem[i].SetActive(true);
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            is_hit = true;
            if (GetComponent<GravityItem>().is_get_downgravity == true)
            {
                is_check = true;
            }
            puzzle1_is_start = false;
            hp--;
            o2.fillAmount = 1.0f;
            //죽어서 respawn시, item respawn
            for (int i = 0; i < gravityitem.Length; i++)
                gravityitem[i].SetActive(true);
        }

        if(other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Success_Stage1");
        }
    }
}

