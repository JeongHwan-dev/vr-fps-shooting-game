using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitCube : MonoBehaviour,IDamageable {
	public float hp = 100f;					// HP 설정
	static int monsterCount = 50;   // 몬스터 몇마리 잡아야 하는지
	public GameObject monsterMon;

	public void OnDamage(float damage)
	{
		Debug.Log("큐브가 맞았다!");
		hp -= damage;		// 데미지 만큼 HP 에서 감소

		if(hp <= 0)			// HP가 0 이하로 떨어지면
		{
			Destroy(gameObject);	// 게임오브젝트 삭제
			monsterMon.gameObject.SetActive(false);

			monsterCount -= 1;	// 몬스터 카운트 -1
		}

		if(monsterCount == 0){		// 몬스터 카운트가 0 이되면
			SceneManager.LoadScene("VRWinScene");		// VRWinScene 으로 로딩
            monsterCount = 50;	// 몬스터 카운트 다시 50으로 초기화
		}
	}
}
