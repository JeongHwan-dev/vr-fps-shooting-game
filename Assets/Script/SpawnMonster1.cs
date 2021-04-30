using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster1 : MonoBehaviour
{

    public GameObject objectToSpawn;
    public float spawnDelay = 20.0f;    // 오브젝트 선언
    public bool enableSpawn = true;     // 스폰 딜레이 값
    public float countDown;
    public int countDownNum = 1;        // 최대 생성 몬스터 수

    // 초기화
    void Start()
    {
        countDown = spawnDelay;
    }

    // 한 프레임당 계속 호출되는 Update 함수
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)      // 카운트 다운이 0 이하가 되었을 경우
        {
            if (enableSpawn)    // 몬스터 스폰 활성화 상태
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation);
                countDown = spawnDelay;
                print("resetting");
            }
            countDownNum--;

            if (countDownNum == 0)      // 최대 생성 몬스터 수를 달성하였을 경우
            {
                enableSpawn = false;    // 몬스터 스폰 비활성화
            }
        }

    }
}
