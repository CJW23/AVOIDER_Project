using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlay : MonoBehaviour
{
    public GameObject spawnObject;

    void Start()
    {
        for (int i = 0; i < 100; i++)
            InvokeRepeating("Respawn", 3, 2f);
    }
    void Respawn()
    {
        GameObject Inst = Instantiate(spawnObject, transform.position, transform.rotation) as GameObject;
        Destroy(Inst, 5.0f);
    }
}
/*    public bool enablespawn = false;
    public GameObject obstacle;

    void SpawnObstacle()
    {
        float randomx = Random.Range(-0.5f, 0.5f);
        if (enablespawn)
        {
            GameObject enemy = (GameObject)Instantiate(obstacle, new Vector3(randomx, 1.1f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
        }
    }

    public static float Range(float v1, float v2)
    {
        throw new NotImplementedException();
    }

    void Start () {
        InvokeRepeating("SpawnObstacle", 3, 5);
	}
}*/
