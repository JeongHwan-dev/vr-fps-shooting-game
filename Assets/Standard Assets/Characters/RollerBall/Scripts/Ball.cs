using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float m_MovePower = 5; 
        [SerializeField] private bool m_UseTorque = true; 
        [SerializeField] private float m_MaxAngularVelocity = 25; 
        [SerializeField] private float m_JumpPower = 2;

        private const float k_GroundRayLength = 1f; 
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            if (m_UseTorque)
            {
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }

            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}
