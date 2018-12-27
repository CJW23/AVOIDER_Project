/*
 조 : 진리아 아재들(2조)
 프로그램 이름 : Randomcontrol.cs
 구현 : 황동현, 김효건
 프로그램 설명 : 맵에 장애물을 랜덤으로 배치해주는 프로그램.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading; //Thread.Sleep 사용

public class RandomControl : MonoBehaviour
{
    float a;
    public bool b;
    public static RandomControl rc;
    public float cnt;
    public GameObject spawnObject;
    public GameObject spawnObject2;
    public GameObject spawnObject3;
    public GameObject spawnObject4;
    public GameObject spawnObject5;
    public GameObject spawnObject6;
    public GameObject spawnObject7;
    public GameObject spawnObject8;
    public GameObject spawnObject9;
    public GameObject[] Inst = null;
    int[] list = new int[25];
    int i;
    void Start()
    {
        rc = this;
        Inst = new GameObject[25];
        Respawn();
        b = false;
        sound1.crush = false;
    }
    void Update()
    {

        //구현 : 김효건
        if (KinectPointController.KB.transform.position.x == 5000)
        {
            for (int i = 0; i < 25; i++)
            {

                Destroy(Inst[i]);

            }
            this.Start();
        }
        for (int i = 0; i < 25; i++)
        {
            if (KinectPointController.KB.transform.position.z == Inst[i].transform.position.z )
            {
                if ((KinectPointController.KB.transform.position.x >= Inst[i].transform.position.x) && (KinectPointController.KB.transform.position.x <=1+Inst[i].transform.position.x) && b)
                {
                    KinectPointController.KB.MoveSpeed = 50;
                    
                    b = false;
                }
                else if ((KinectPointController.KB.transform.position.x >= Inst[i].transform.position.x) && (KinectPointController.KB.transform.position.x <= KinectPointController.KB.MoveSpeed/50* 3 + Inst[i].transform.position.x)&& !b)
                {
                    sound1.crush = true;
                    Vector3 pos;
                    pos.x = Inst[i].transform.position.x+2;
                    pos.y = 0.8f;
                    pos.z = KinectPointController.KB.transform.position.z;
                    KinectPointController.KB.transform.position = pos;
                    KinectPointController.KB.MoveSpeed = 50;
                    KinectPointController.KB.MoveSpeed = 0.5f;
                    
                    b = true;
                }
            }
            else
            {
                if ((KinectPointController.KB.transform.position.x >= Inst[i].transform.position.x) && (KinectPointController.KB.transform.position.x <= KinectPointController.KB.MoveSpeed / 50 * 3 + Inst[i].transform.position.x))
                {
                    if (KinectPointController.KB.MoveSpeed <= 150)
                    {
                        cnt += 5f;
                        KinectPointController.KB.MoveSpeed += 5f;
                    }
                }
            }
        }
    }
    void Respawn()
    {

        //구현 : 황동현
        int[] num = new int[4] { 0, 314, 349, 384 };
        for (int i = 0; i < 25; i++)
            list[i] = 5000 - (150 * (i + 1));
        for (i = 0; i < 25; i++)
        {
            int value = Random.Range(1, 10); //장애물 번호
            int value2 = Random.Range(1, 4);  //z축 
            if (value == 1)
            {
                Inst[i] = Instantiate(spawnObject, spawnObject.transform.position, spawnObject.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 2)
            {
                Inst[i] = Instantiate(spawnObject2, spawnObject2.transform.position, spawnObject2.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 3)
            {
                Inst[i] = Instantiate(spawnObject3, spawnObject3.transform.position, spawnObject3.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 4)
            {
                Inst[i] = Instantiate(spawnObject4, spawnObject4.transform.position, spawnObject4.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 5)
            {
                Inst[i] = Instantiate(spawnObject5, spawnObject5.transform.position, spawnObject5.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 6)
            {
                Inst[i] = Instantiate(spawnObject6, spawnObject6.transform.position, spawnObject6.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 7)
            {
                Inst[i] = Instantiate(spawnObject7, spawnObject7.transform.position, spawnObject7.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 8)
            {
                Inst[i] = Instantiate(spawnObject8, spawnObject8.transform.position, spawnObject8.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
            else if (value == 9)
            {
                Inst[i] = Instantiate(spawnObject9, spawnObject9.transform.position, spawnObject9.transform.rotation) as GameObject;
                if (value2 == 1)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 2)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
                else if (value2 == 3)
                    Inst[i].transform.position = new Vector3(list[i], Inst[i].transform.position.y, num[value2]);
            }
        }
    }
}