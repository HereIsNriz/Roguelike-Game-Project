using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    public bool IsGameRunning;
    public int Score;

    [SerializeField] private GameObject[] m_tress;
    [SerializeField] private GameObject m_gameOverPanel;
    [SerializeField] private TextMeshProUGUI m_scoreText;

    private float m_spawnDelay;
    private float m_minSpawnDelay = 2f;
    private float m_maxSpawnDelay = 4f;
    private float m_boundary = 14f;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGameRunning = true;
        Score = 0;
        StartCoroutine(SpawnTrees());
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        UpdateScoreText();
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

    private void GameOver()
    {
        if (!IsGameRunning)
        {
            m_scoreText.gameObject.SetActive(false);
            m_gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateScoreText()
    {
        m_scoreText.text = $"Score:\n{Score}";
    }
}
