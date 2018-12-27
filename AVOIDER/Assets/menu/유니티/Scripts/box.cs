/*
 조 : 진리와 아재들(2조)
 조원 : 최재우, 김라희, 김효건, 황동현
 프로젝트 명 : AVOIDER
 소스 파일명 : box.cs
 작성일 : 2017/11/13
 작성자 : 2014041005 최재우
 프로그램 설명 : 맵을 조금씩 이동시키는 프로그램
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    float speed = 0.1f;
    float term=15;
    float temp;
    Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
        temp = trans.position.z;
    }

    void Update()
    {
        Vector3 pos = new Vector3();
        pos.y = trans.position.y;
        pos.x = trans.position.x;
        pos.z = trans.position.z - speed;
        trans.position = pos;
        if(temp-term>trans.position.z)
        {
            term += 10;
            temp = trans.position.z;
            speed += 0.05f;
        }
    }
}
