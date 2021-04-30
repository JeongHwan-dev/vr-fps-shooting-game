using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chase : MonoBehaviour {

    public Transform Target;                // 타깃 설정
    Animator anim;  
    public int TrackingDistance = 1000;     // 추적 거리
    public int AttackRange = 3;             // 공격 범위
    public float WalkingSpeed = 0.05f;      // 걷는 속도
    private bool target_alive;              // 타깃 유무
    public float AttackDamage = 5.0f;       // 공격 데미지

    private bool done = false;

    // 초기화
    void Start()
    {
        // 애니메이션 설정
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isAttacking", false);

        print("Target: " + Target);
    }

    void findNextTarget()
    {
        Debug.Log("Finding next target...");
        GameObject[] temp;
        bool done = false;
        temp = GameObject.FindGameObjectsWithTag("Player");     // 타깃 설정
        for (int i = 0; i < temp.Length; i++)
        {
            if (!done)
            {
                Debug.Log("FOUND Player:" + temp[i].name);
                if (temp[i].name != null)
                {
                    Debug.Log("Setting New TARGET! YEAHHH!");
                    Target = temp[i].GetComponent<Transform>();
                    done = true;
                }
            }
        }
        if (temp.Length == 0)   // 타깃이 모두 제거되었을 경우
        {
            SceneManager.LoadScene("VRLooseScene");     // VRLooseScene 으로 로딩
        }
    }

    void Update()
    {
        if (Target != null)
        {
            target_alive = Target.GetComponent<Health>().alive;

            if (target_alive &&
                (Vector3.Distance(Target.position, this.transform.position)
                < TrackingDistance))
            {
                Vector3 direction = Target.position - this.transform.position;
                direction.y = 0; 
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                    Quaternion.LookRotation(direction), 0.1f);
                anim.SetBool("isWalking", true);

                if (direction.magnitude > AttackRange)
                {
                    anim.SetBool("isWalking", true);
                    this.transform.Translate(0, 0, WalkingSpeed);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isIdle", false);
                }
                else
                {
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", false);
                }

            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            findNextTarget();
        }
    }
}
