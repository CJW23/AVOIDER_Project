using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class inputt : MonoBehaviour
{
    // Use this for initialization
    bool t = true;
    // Update is called once per frame
    public void button_click()
    {
        if (t)
        {
            //FileStream fs = new FileStream("rank.txt", FileMode.Open,FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs);
            //sw.WriteLine(gettext.g.t.text+" "+instance.ins.scoreText.text);
            System.IO.File.AppendAllText("rank.txt", gettext.g.t.text + " " + instance.ins.scoreText.text+"\r\n", System.Text.Encoding.Default);
            //sw.Close();
            t = false;
        }
    }
}