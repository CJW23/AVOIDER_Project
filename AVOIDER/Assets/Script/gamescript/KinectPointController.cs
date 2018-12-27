/*
 조 : 진리와아재들(2조)
 구현 : 최재우
 프로그램 이름 : KinectPointController.cs
 프로그램 설명 : 키넥트 동작 인식을 하여 캐릭터를 이동하는 프로그램
 */

using UnityEngine;
using System;
using System.Collections;

public class KinectPointController : MonoBehaviour
{
    public static KinectPointController KB;
    public const float LEND = 314;
    public const float MIDDLE = 349;
    public const float REND = 384;
    bool bb;
    public float MoveSpeed = 50f;
    public float RotateSpeed = 40f;
    public bool moving = false;
    private CharacterController controller;
    public Animation anim;
    float i = MIDDLE;
    int location = 2;
    public bool init = false;
    bool rmoving = false;
    bool lmoving = false;
    public bool check;
    Transform transform;
    Vector3 pos = new Vector3();
   //키넥트 소스
    public enum BoneMask
    {
        None = 0x0,
        Hip_Center = 0x1,
        Spine = 0x2,
        Shoulder_Center = 0x4,
        Head = 0x8,
        Shoulder_Left = 0x10,
        Elbow_Left = 0x20,
        Wrist_Left = 0x40,
        Hand_Left = 0x80,
        Shoulder_Right = 0x100,
        Elbow_Right = 0x200,
        Wrist_Right = 0x400,
        Hand_Right = 0x800,
        Hip_Left = 0x1000,
        Knee_Left = 0x2000,
        Ankle_Left = 0x4000,
        Foot_Left = 0x8000,
        Hip_Right = 0x10000,
        Knee_Right = 0x20000,
        Ankle_Right = 0x40000,
        Foot_Right = 0x80000,
        All = 0xFFFFF,
        Torso = 0x10000F, //the leading bit is used to force the ordering in the editor
        Left_Arm = 0x1000F0,
        Right_Arm = 0x100F00,
        Left_Leg = 0x10F000,
        Right_Leg = 0x1F0000,
        R_Arm_Chest = Right_Arm | Spine,
        No_Feet = All & ~(Foot_Left | Foot_Right),
        UpperBody = Shoulder_Center | Head | Shoulder_Left | Elbow_Left | Wrist_Left | Hand_Left |
        Shoulder_Right | Elbow_Right | Wrist_Right | Hand_Right

    }
    public SkeletonWrapper sw;
    public GameObject Hip_Center;
    public GameObject Spine;
    public GameObject Shoulder_Center;
    public GameObject Head;
    public GameObject Shoulder_Left;
    public GameObject Elbow_Left;
    public GameObject Wrist_Left;
    public GameObject Hand_Left;
    public GameObject Shoulder_Right;
    public GameObject Elbow_Right;
    public GameObject Wrist_Right;
    public GameObject Hand_Right;
    public GameObject Hip_Left;
    public GameObject Knee_Left;
    public GameObject Ankle_Left;
    public GameObject Foot_Left;
    public GameObject Hip_Right;
    public GameObject Knee_Right;
    public GameObject Ankle_Right;
    public GameObject Foot_Right;
    private GameObject[] _bones; 
    public int player;
    public BoneMask Mask = BoneMask.All;

    public float scale = 1.0f;

    // Use this for initialization
    void Start()
    {
        KB = this;

        //store bones in a list for easier access
        _bones = new GameObject[(int)Kinect.NuiSkeletonPositionIndex.Count] {Hip_Center, Spine, Shoulder_Center, Head,
            Shoulder_Left, Elbow_Left, Wrist_Left, Hand_Left,
            Shoulder_Right, Elbow_Right, Wrist_Right, Hand_Right,
            Hip_Left, Knee_Left, Ankle_Left, Foot_Left,
            Hip_Right, Knee_Right, Ankle_Right, Foot_Right};
        //_bonePos = new Vector4[(int)BoneIndex.Num_Bones];
        controller = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        sound1.sd.StartCoroutine("pl");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == -1)
            return;
        //update all of the bones positions
        if (sw.pollSkeleton())
        {
            for (int ii = 0; ii < (int)Kinect.NuiSkeletonPositionIndex.Count; ii++)
            {
                //_bonePos[ii] = sw.getBonePos(ii);
                if (((uint)Mask & (uint)(1 << ii)) > 0)
                {
                    //_bones[ii].transform.localPosition = sw.bonePos[player,ii];
                    _bones[ii].transform.localPosition = new Vector3(
                        sw.bonePos[player, ii].x * scale,
                        sw.bonePos[player, ii].y * scale,
                        sw.bonePos[player, ii].z * scale);
                }
            }
        }
        Move();





    }
    
    void Move()
    {
        if (RandomControl.rc.b)
        {
            anim.Play("Zombie Die_01");
        }
        else
        {
            anim.Play();
        }
        
        if (Hand_Left.transform.position.y > 16.0f)     //키넥트에서 왼손의 위치가 일정 수준 올라가면
        {
            if (rmoving == false && lmoving == false)       //왼쪽, 오른쪽 움직임이 없다면
            {
                if (i == MIDDLE || i == REND)       //캐릭터의 위치가 중앙에 있거나 오른쪽에 있으면
                {
                    sound1.hwik = true;     //이동하는 소리 출력
                    rmoving = false;        //오른쪽으로 이동하라는 신호를 끄고
                    if (i == MIDDLE)        //캐릭터가 중앙에 있다면 
                    {
                        i = LEND;           //왼쪽으로 좌표 이동
                        location = 1;
                    }
                    else                    //캐릭터가 오른쪽에 있다면
                    {
                        i = MIDDLE;         //중앙으로 좌표 이동
                        location = 2;
                    }
                    lmoving = true;         //왼쪽 움직임 신호
                }
            }
        }
        //  Debug.Log("Right " + Hand_Right.transform.position.y);
        if (Hand_Right.transform.position.y > 16.0f)
        {

            if (rmoving == false && lmoving == false)
            {
                if (i == MIDDLE || i == LEND)
                {
                    sound1.hwik = true;
                    lmoving = false;
                    if (i == MIDDLE)
                    {
                        i = REND;
                        location = 3;
                    }
                    else
                    {
                        i = MIDDLE;
                        location = 2;
                    }
                    rmoving = true;

                }
            }
        }
        //캐릭터를 이동시키는 구문
        if (!RandomControl.rc.b)
        {
            if (lmoving == true)
            {
                this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
                if (this.transform.position.z <= i)
                {
                    pos.x = this.transform.position.x;
                    pos.y = this.transform.position.y;
                    pos.z = i;
                    transform.position = pos;
                    lmoving = false;
                }
            }
            if (rmoving == true)
            {
                this.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
                if (this.transform.position.z >= i)
                {
                    pos.x = this.transform.position.x;
                    pos.y = this.transform.position.y;
                    pos.z = i;
                    transform.position = pos;
                    rmoving = false;
                }
            }
        }
        this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        if (this.transform.position.x < 2000)       //맵의 일정 구간까지 가면 다시 맵 처음으로 돌아가는 함수
        {
            pos.x = 5000;
            pos.y = 0;
            pos.z = 349;
            transform.position = pos;
            rmoving = true;
            lmoving = true;
            init = true;
            check = true;
            sound1.sd.Start();

        }

    }
    public void SetMoving(bool a)
    {
        moving = a;
    }
    public bool GetMoving()
    {
        return moving;
    }
    public int GetLocation()
    {
        return location;
    }
    public bool GetInit()
    {
        return init;
    }
    public void SetInit(bool a)
    {
        init = a;
    }
}
