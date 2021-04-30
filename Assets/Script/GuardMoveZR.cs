using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMoveZR : MonoBehaviour
{
    Vector3 pos;            // 현재 위치
    float delta = 3.5f;     // 좌우로 이동가능한 x 최대값
    float speed = 0.45f;    // 이동속도

    // 초기화 함수
    void Start()
    {
        pos = transform.position;
    }

    // frame 마다 계속 호출
    void Update()
    {
        Vector3 v = pos;
        
        v.z -= delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
