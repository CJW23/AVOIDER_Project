/*
 조 : 진리와아재들(2조)
 조원 : 최재우, 황동현, 김효건, 김라희
 프로그램 이름 : PlayerContro.cs
 프로그램 설명 : 캐릭터의 움직임을 구현한 프로그램
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playcontrol : MonoBehaviour
{
    public const float LEND = 300;
    public const float MIDDLE = 335;
    public const float REND = 369;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 40f;
    public float MovingSpeed = 10f;

    private CharacterController controller;
    public Animation anim;
    float i = MIDDLE;
    bool rmoving = false;
    bool lmoving = false;
    Transform transform;
    Vector3 pos = new Vector3();
    void Start()
    {
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        Move();

        if (controller.velocity.magnitude > 0)
        {
            anim.Play("Back_45Degree_AirStab_01_001");
        }
        else// if(this.transform.position.z <310)
        {
            anim.Play("Back_45Degree_AirStab_01_001");
        }
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            if (i == MIDDLE || i == REND)
            {
                rmoving = false;
                if (i == MIDDLE)
                    i = LEND;
                else
                    i = MIDDLE;
                lmoving = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) == true)
        {

            if (i == MIDDLE || i == LEND)
            {
                lmoving = false;
                if (i == MIDDLE)
                    i = REND;
                else
                    i = MIDDLE;
                rmoving = true;
            }
        }
        if (lmoving == true)
        {
            this.transform.Translate(Vector3.left * MovingSpeed * Time.deltaTime);
            if (this.transform.position.z <= i)
            {
                pos.x = this.transform.position.x;
                pos.y = this.transform.position.y;
                pos.z = i;
                transform.position = pos;
                lmoving = false;
            }
        }
        if (rmoving == true)
        {
            this.transform.Translate(Vector3.right * MovingSpeed * Time.deltaTime);
            if (this.transform.position.z >= i)
            {
                pos.x = this.transform.position.x;
                pos.y = this.transform.position.y;
                pos.z = i;
                transform.position = pos;
                rmoving = false;
            }
        }
        this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        //if (this.transform.position.z >= 60)
        //{
        //    pos.x = 5000;
        //    pos.y = 0;
        //    pos.z = 350;
        //    transform.position = pos;
        //    rmoving = true;
        //    lmoving = true;
        //}

    }
}

