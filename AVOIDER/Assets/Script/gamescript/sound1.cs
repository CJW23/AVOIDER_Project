/*
 조 : 진리와 아재들(2조)
 구현 : 최재우
 프로그램 이름 : sound1.cs
 프로그램 설명 : 캐릭터가 장애물에 접근하는 것을 알려주는 경고음 프로세스 
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine.SceneManagement;

public class sound1 : MonoBehaviour
{
    public static bool hwik = false;
    public static bool crush = false;
    public static sound1 sd;
    bool wait = true;
    bool a = true;
    int i = 0;
    int j;
    int instance= 0;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;
    // Use this for initialization
    AudioSource source;
    public void Start()
    {
        sd = this;
        source = GetComponent<AudioSource>();
        StartCoroutine("pl");
        hwik = false;
        crush = false;
        wait = true;
        a = true;
    }
    void Update()
    {
        if(hwik == true)
        {
            source.PlayOneShot(sound4);
        
            hwik = false;
        }
        if (a == true && StartCoroutine("pl") != null)
            a = false;
        
        for (j = i; j < 25; j++)        //장애물 숫자 
        {
            if (KinectPointController.KB.GetLocation() == 1)        //캐릭터의 위치가 첫번째 길이면서
            {
                if (RandomControl.rc.Inst[j].transform.position.z == 314)       //장애물의 위치도 첫번째 길이면
                {
                    break;          // j라는 인덱스를 가지고 break
                }
            }
            else if (KinectPointController.KB.GetLocation() == 2)   //캐릭터의 위치가 두번째 길이면서

            {
                if (RandomControl.rc.Inst[j].transform.position.z == 349)       //장애물의 위치도 두번째 길이면
                {
                    break;          // j라는 인덱스를 가지고 break
                }
            }
            else if (KinectPointController.KB.GetLocation() == 3)   //캐릭터의 위치가 세번째 길이면서
            {
                if (RandomControl.rc.Inst[j].transform.position.z == 384)       //장애물의 위치도 세번째 길이면
                {
                    break;          // j라는 인덱스를 가지고 break
                }
            }
        }


        if (RandomControl.rc.Inst[i].transform.position.x > KinectPointController.KB.transform.position.x)      //캐릭터가 가장 앞에 있는 장애물 좌표를 넘을시 다음 장애물로 변경
        {
            i += 1;
        }

        if (wait == true)
        {
            //Debug.Log("Why");
            if (!RandomControl.rc.b)
            {
                
                if (timerer.ti.second != "0") {
                    source.PlayOneShot(sound2);
                    Debug.Log(End.end.t+"aaaaaaa");
                }
                wait = false;
            }
           if(crush == true)
            {
                source.PlayOneShot(sound3);
                crush = false;
            }
        }

        //if (KinectPointController.KB.init == true)      //캐릭터가 처음 위치로 돌아갔다면
        //{
        //    // Debug.Log("3");
        //    i = 0;
        //    KinectPointController.KB.init = false;
        //}
        if (KinectPointController.KB.GetInit() == true)
        {
            i = 0;
            j = 0;
            KinectPointController.KB.SetInit(false);
        }
    }
    
        

    void play_()
    {
       
        source.PlayOneShot(sound2);
    }
    IEnumerator pl()
    {
        while (true)
        {
            //Debug.Log(KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x);
            if ((KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x) < 500.0f && 
                (KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x) > 400.0f)         //캐릭터와 장애물의 간격이 500이하이면서 400이상이고 서로 같은 길에 있으면(z축이 같으면)
            { 
                yield return new WaitForSeconds(0.9f);  //0.5초 뒤에 명령어 실행
                if (wait == false)
                    wait = true;        //소리 출력

            }
            else if ((KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x) < 399.0f && 
                (KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x) > 200.0f)      //캐릭터와 장애물의 간격이 399이하이면서 200이상이고 서로 같은 길에 있으면
            {
               // Debug.Log(KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x);
                yield return new WaitForSeconds(0.3f);  //0.1초 뒤에 명령어 실행
                if (wait == false)
                    wait = true;        //소리 출력
            }
            else if((KinectPointController.KB.transform.position.x - RandomControl.rc.Inst[j].transform.position.x) < 200.0f)       //캐릭터와 장애물의 거리가 200이하이면서 서로 같은 길에 있으면
            {
                yield return new WaitForSeconds(0.1f);  //0.5초 뒤에 명령어 실행
                if (wait == false)
                    wait = true;        //소리 출력 
            }
           
            else
            {
                yield return new WaitForSeconds(0.1f);  //0.5초 뒤에 명령어 실행
            }
           
        }
    }



}