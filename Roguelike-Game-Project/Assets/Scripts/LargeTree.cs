using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class LargeTree : TreeController
{
    private float m_xPosition = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_isReadyToMove = false;
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        Poin = 2;
        StartCoroutine(MoveTree());
    }

    private void Update()
    {
        if (m_isReadyToMove)
        {
            transform.Translate(GenerateTreePosition() * m_treeMoveSpeed * Time.deltaTime);
        }
        if (transform.position.x > 20f)
        {
            Destroy(gameObject);
            mainManager.IsGameRunning = false;
        }
    }

    // POLYMORPHISM
    public override Vector3 GenerateTreePosition()
    {
        treePosition = new Vector3(m_xPosition, transform.position.y, transform.position.z);
        return treePosition;
    }
}
