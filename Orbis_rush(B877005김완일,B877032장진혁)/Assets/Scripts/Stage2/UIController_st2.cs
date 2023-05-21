using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController_st2 : MonoBehaviour
{
    public Image o2;
    public Image gravity;
    public Image hp1, hp2, hp3;

    public Player_st2 player;
    SavePoint save_point;
    bool save1_worked;
    bool save2_worked;

    void Start()
    {
        gravity.fillAmount = Physics.gravity.magnitude / 20f;
        player = GameObject.Find("Player").GetComponent<Player_st2>();
        save_point = GameObject.Find("Player").GetComponent<SavePoint>();
        save1_worked = false;
        save2_worked = false;
    }

    // Update is called once per frame
    void Update()
    {
        UiUpdate();
    }
    void UiUpdate()
    {

        if(save_point.isSave1 && !save1_worked)
        {
            save1_worked = true;
            save2_worked = false;
            o2.fillAmount = 1f;
        }

        else if(save_point.isSave2 && !save2_worked)
        {
            save2_worked = true;
            save1_worked = false;
            o2.fillAmount = 1f;
        }

        
        o2.fillAmount -= Time.deltaTime * 0.01f;
        
        if (o2.fillAmount < 0.2)
            o2.color = new Color(255, 0, 0);
        else if (o2.fillAmount < 0.5)
            o2.color = new Color(255, 150, 0);
        else
            o2.color = new Color(0, 200, 255);

        if (gravity.fillAmount < 0.33)
            gravity.color = new Color(0, 255, 0);
        else if (gravity.fillAmount < 0.66)
            gravity.color = new Color(100, 0, 200);
        else
            gravity.color = new Color(150, 0, 0);

        if (player.hp == 2)
            hp3.enabled = false;
        else if (player.hp == 1)
            hp2.enabled = false;
        else if (player.hp == 0)
            hp1.enabled = false;

    }
}
