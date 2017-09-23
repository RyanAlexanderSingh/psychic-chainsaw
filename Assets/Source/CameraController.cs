using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] Transform m_target;
	[SerializeField] Vector3 m_offset;
	[SerializeField] float m_pitch = 2f;

	[SerializeField] float m_zoomSpeed = 0.5f;
	[SerializeField] float m_defaultZoom = 1.5f;
	[SerializeField] float m_minZoom = 1f;
	[SerializeField] float m_maxZoom = 3f;

	private float m_currentZoom = 2.5f;

	// ------------------------------------------------------------------------------
	void Start()
	{
		m_currentZoom = m_defaultZoom;
	}

	// ------------------------------------------------------------------------------
	void Update()
	{
		m_currentZoom -= Input.GetAxis("Mouse ScrollWheel") * m_zoomSpeed;
		m_currentZoom = Mathf.Clamp(m_currentZoom, m_minZoom, m_maxZoom);
	}

	// ------------------------------------------------------------------------------
	void LateUpdate()
	{
		transform.position = m_target.position - m_offset * m_currentZoom;
		transform.LookAt(m_target.position + Vector3.up * m_pitch);
	}
}
