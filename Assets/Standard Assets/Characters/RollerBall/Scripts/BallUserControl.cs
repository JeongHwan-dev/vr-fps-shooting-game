using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; 

        private Vector3 move;

        private Transform cam; 
        private Vector3 camForward; 
        private bool jump; 


        private void Awake()
        {
            ball = GetComponent<Ball>();


            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            }
        }


        private void Update()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            jump = CrossPlatformInputManager.GetButton("Jump");

            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v*camForward + h*cam.right).normalized;
            }
            else
            {
                move = (v*Vector3.forward + h*Vector3.right).normalized;
            }
        }

        private void FixedUpdate()
        {
            ball.Move(move, jump);
            jump = false;
        }
    }
}
