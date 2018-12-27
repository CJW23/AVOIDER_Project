/*
조 : 진리와아재들(2조)
구현 : 최재우
프로그랢 이름 : instance.cs
프로그램 설명 : 달린 거리를 표현해주는 프로그램.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instance : MonoBehaviour {
    public static float s,t = 0;
    public Text scoreText;
    public static instance ins;
	// Use this for initialization
	void Start () {

        ins = this;
    }
	
	// Update is cald once per framedd
	void Update () {
        s = t + 4993f - KinectPointController.KB.transform.position.x;
        if (KinectPointController.KB.check)
        {
            t += 3000;
            KinectPointController.KB.check = false;
        }
        else
            scoreText.text = ((int)s).ToString() + "m";
    }

}
