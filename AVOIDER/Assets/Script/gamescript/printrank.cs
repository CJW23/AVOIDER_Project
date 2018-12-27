/*
조 : 진리와 아재들(2조)
구현 : 김효건
프로그램 이름 : printrank.cs
프로그램 설명 : 랭킹 출력
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;

public class printrank : MonoBehaviour {
    public  Text t;
    string[] ranker = new string[100];
    
    // Use this for initialization
    void Start() {
        string line;

        using (StreamReader rdr = new StreamReader("rank.txt"))
        {
            int i = 1;
            t.text += "\r\n";
            while ((line = rdr.ReadLine()) != null)
            {
                t.text += "               ";
                t.text += i + " rank        ";
                t.text += line;
                t.text += "         ";
                t.text += "\r\n\r\n";
                i++;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
