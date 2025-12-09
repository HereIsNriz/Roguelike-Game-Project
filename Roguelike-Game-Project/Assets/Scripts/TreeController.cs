using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public int Poin;
    private int m_poin
    {
        // ENCAPSULATION
        get { return Poin; }
        set
        {
            if (Poin < 0)
            {
                Debug.LogError("Poin can not set to a negative number");
            }
            else
            {
                Poin = value;
            }
        }
    }

    protected Vector3 treePosition;
    protected MainManager mainManager;
    protected float m_moveDelay = 2f;
    protected float m_treeMoveSpeed = 1f;
    protected bool m_isReadyToMove;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            mainManager.Score += m_poin;
        }
    }

    protected IEnumerator MoveTree()
    {
        yield return new WaitForSeconds(m_moveDelay);

        m_isReadyToMove = true;
    }

    // ABSTRACTION
    public virtual Vector3 GenerateTreePosition()
    {
        return treePosition;
    }
}
