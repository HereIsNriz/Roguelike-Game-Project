using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MediumTree : TreeController
{
    private float m_zPosition = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_isReadyToMove = false;
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        Poin = 5;
        StartCoroutine(MoveTree());
    }

    private void Update()
    {
        if (m_isReadyToMove)
        {
            transform.Translate(GenerateTreePosition() * m_treeMoveSpeed * Time.deltaTime);
        }
        if (transform.position.z > 20f)
        {
            Destroy(gameObject);
            mainManager.IsGameRunning = false;
        }
    }

    // POLYMORPHISM
    public override Vector3 GenerateTreePosition()
    {
        treePosition = new Vector3(transform.position.x, transform.position.y, m_zPosition);
        return treePosition;
    }
}
