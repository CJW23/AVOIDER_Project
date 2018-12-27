/*
 조 : 진리와아재들(2조)
 조원 : 최재우, 황동현, 김효건, 김라희
 프로그램 이름 : PlayerContro.cs
 프로그램 설명 : 캐릭터의 움직임을 구현한 프로그램
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContro : MonoBehaviour
{
    public const float LEND = -4;
    public const float MIDDLE = 0;
    public const float REND = 4;
    public float MoveSpeed = 10f;
    public float RotateSpeed = 40f;
    private CharacterController controller;
    public Animation anim;
    float i = 0;
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
            anim.Play("assault_combat_run");
        }
        else
        {
            anim.Play("assault_combat_run");
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
            this.transform.Translate(Vector3.left * 10.0f * Time.deltaTime);
            if (this.transform.position.x <= i)
            {
                pos.x = i;
                pos.y = this.transform.position.y;
                pos.z = this.transform.position.z;
                transform.position = pos;
                lmoving = false;
            }
        }
        if (rmoving == true)
        {
            this.transform.Translate(Vector3.right * 10.0f * Time.deltaTime);
            if (this.transform.position.x >= i)
            {
                pos.x = i;
                pos.y = this.transform.position.y;
                pos.z = this.transform.position.z;
                transform.position = pos;
                rmoving = false;
            }
        }
        this.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
        if (this.transform.position.z >= 60)
        {
            pos.x = MIDDLE;
            pos.y = 0;
            pos.z = 0;
            transform.position = pos;
            rmoving = false;
            lmoving = false;
        }
        
    }
}

