using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed;

    private float m_verticalInput;
    private float m_horizontalInput;
    private float m_boundary = 15f;

    // Update is called once per frame
    void Update()
    {
        m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");

        KeepPlayerInBound();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_horizontalInput, 0, m_verticalInput).normalized;
        transform.Translate(movement * m_speed * Time.deltaTime);
    }

    // ABSTRACTION
    private void KeepPlayerInBound()
    {
        if (transform.position.x <= -m_boundary)
        {
            transform.position = new Vector3(-m_boundary, transform.position.y, transform.position.z);
        }else if (transform.position.x >= m_boundary)
        {
            transform.position = new Vector3(m_boundary, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= -m_boundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -m_boundary);
        }else if (transform.position.z >= m_boundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, m_boundary);
        }
    }
}
