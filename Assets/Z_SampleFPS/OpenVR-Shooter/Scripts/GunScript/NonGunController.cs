using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonGunController : MonoBehaviour {
    // 단 두개의 함수 Input.GetKeyDown(KeyCode.R) 와 Input.GetButtonDown("Fire1")
    public Gun gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gun.Reload();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gun.Fire();
        }
    }
}
