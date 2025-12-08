using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public bool IsGameRunning;

    [SerializeField] private GameObject[] m_tress;

    private float m_spawnDelay;
    private float m_minSpawnDelay = 2f;
    private float m_maxSpawnDelay = 4f;
    private float m_boundary = 14f;

    // Start is called before the first frame update
    void Start()
    {
        IsGameRunning = true;
        StartCoroutine(SpawnTrees());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnTrees()
    {
        while (IsGameRunning)
        {
            yield return new WaitForSeconds(GenerateRandomDelay());

            int randomTrees = Random.Range(0, m_tress.Length);

            Instantiate(m_tress[randomTrees], GenerateSpawnLocation(), Quaternion.identity);
        }
    }

    private float GenerateRandomDelay()
    {
        m_spawnDelay = Random.Range(m_minSpawnDelay, m_maxSpawnDelay);
        return m_spawnDelay;
    }

    private Vector3 GenerateSpawnLocation()
    {
        Vector3 treesBoundary = new Vector3(GenerateXZ(), 4, GenerateXZ());
        return treesBoundary;
    }

    private float GenerateXZ()
    {
        float m_randomSpawnLocation = Random.Range(-m_boundary, m_boundary);
        return m_randomSpawnLocation;
    }
}
