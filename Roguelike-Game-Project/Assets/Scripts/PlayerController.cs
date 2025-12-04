using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed;

    private float m_verticalInput;
    private float m_horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_horizontalInput, 0, m_verticalInput);
        transform.Translate(movement * m_speed * Time.deltaTime);
    }
}
