/*
조 : 진리와 아재들
구현 : 최재우
프로그램 이름 : timerer.cs
프로그램 설명 : 시간초를 새는 프로그램  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerer : MonoBehaviour
{
    public static bool end = false;
    public float t;
    public Text timerText;
    public float startTime = 0;
    public string second;
    public static timerer ti;
    // Use this for initialization
    void Start()
    {
        end = false;
        ti = this;
        startTime = Time.time;
    }
    void Update()
    {
        t = 65-(Time.time - startTime);
    
        second = ((int)(t % 65)).ToString();
        if (t<0)
            second = "0";
        timerText.text = "Time : " + second;

        if (second == "1") { 
            end = true;
       
        }
    }
}
