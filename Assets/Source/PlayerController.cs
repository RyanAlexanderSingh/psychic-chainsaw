using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float m_playerSpeed;
	[SerializeField] float m_rotSpeed;

	PlayerMotor m_pMotor;

	// ------------------------------------------------------------------------------
	void Start () {
		m_pMotor = GetComponent<PlayerMotor>();
	}
	
	// ------------------------------------------------------------------------------
	void Update () 
	{
		float zMov = Input.GetAxisRaw("Vertical");
		Vector3 moveForward = transform.forward * zMov;
		m_pMotor.Move(moveForward);

		Vector3 rot = new Vector3 (0f, Input.GetAxisRaw("Horizontal") * m_rotSpeed, 0);
		m_pMotor.Rotate(rot);
	}
}
