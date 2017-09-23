using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField] float m_jumpDist = 2f;

	private Vector3 m_velocity = Vector3.zero;
	private Vector3 m_rotation = Vector3.zero;

	private Rigidbody m_rb;

	private float m_distToGround;

	// ------------------------------------------------------------------------------
	void Start () {
		m_rb = GetComponent<Rigidbody>();
		m_distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	// ------------------------------------------------------------------------------
	public void Move (Vector3 _vec)
	{
		m_velocity = _vec;
	}

	// ------------------------------------------------------------------------------
	public void Rotate (Vector3 _rot)
	{
		m_rotation = _rot;
	}
	
	// ------------------------------------------------------------------------------
	void FixedUpdate()
	{
		PerformMovement();
		PerformRotation();

		if(Input.GetKeyDown(KeyCode.Space) && IsPlayerGrounded())
		{
			PerformJump();
		}
	}

	// ------------------------------------------------------------------------------
	void PerformMovement()
	{
		if(m_velocity != Vector3.zero)
		{
			var newPos = m_rb.position + m_velocity * Time.fixedDeltaTime;
			m_rb.MovePosition(newPos);
		}
	}

	// ------------------------------------------------------------------------------
	void PerformRotation()
	{
		m_rb.MoveRotation(m_rb.rotation * Quaternion.Euler(m_rotation));
	}

	// ------------------------------------------------------------------------------
	void PerformJump()
	{
		m_rb.AddForce(transform.up * m_jumpDist, ForceMode.Impulse);
	}

	// ------------------------------------------------------------------------------
	bool IsPlayerGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, m_distToGround + 0.05f);
	}
}
