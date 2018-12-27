using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sdime : MonoBehaviour {

    public Text timerText;
    private float startTime;
   
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        timerText.text = minutes;
    }
}
