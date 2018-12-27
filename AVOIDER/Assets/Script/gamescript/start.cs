/*
조 : 진리와아재들(2조)
구현 : 김효건
프로그램 이름 : start.cs
프로그램 설명 : 시작 카운트다운 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour {
    public Text s;
    public float startTime;
    public float i;
    public AudioSource countdown;
    public AudioClip sound1;
    
	// Use this for initialization
	void Start () {
        countdown = GetComponent<AudioSource>();
        startTime = Time.time;
        
        countdown.PlayOneShot(sound1);
	}
	
	// Update is called once per frame
	void Update () {
        if(i>=0 && i<=5)
            KinectPointController.KB.MoveSpeed = 0f;
        if((int)i==0)
            KinectPointController.KB.MoveSpeed = 50f;
        i = 5 - (Time.time - startTime);
        s.text = ((int)i).ToString();
        if ((int)i == 0)
            s.text = "START";
        if (i < 0) { 
            s.text = " ";
        }
    }
}
