/*
조 : 진리와아재들(2조)
구현 : 최재우
프로그램 이름 : End.cs
프로그램 설명 : 게임이 끝났을 때 게임 오버 이미지 출력 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public static End end;
    public bool replay = false;
   
    public float startTime = 0;
    public string second;
    public float t;
    bool c;
    int a = 20;
    public AudioClip gameOverSound;
    RectTransform transform1;
    Vector3 pos = new Vector3();
    bool gmov = false;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        replay = false;
        end = this;
        source = GetComponent<AudioSource>();
        transform1 = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerer.end == true && !c) {
            startTime = Time.time;
            c = true;
        }
        if (timerer.end == true)
        {
            gmov = true;
            //transform.position += Vector3.down;
            this.transform1.Translate(Vector3.down * a * Time.deltaTime);
            t = Time.time - startTime;
            second = ((int)(t % 60)).ToString();
            if(second == "0")
                source.Play();
            if (second == "2") {
                a = 0;
                if (gmov == true)
                {
                    replay = true;  
                    gmov = false;
                }
                KinectPointController.KB.MoveSpeed = 0;
                a = 0;
            }

        }
        
    }
}
