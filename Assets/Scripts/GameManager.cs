using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int targetScore;
    public float timeLimit;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text targetScoreText;

    public GameObject winPanel;
    public GameObject losePanel;

    private int currentScore;
    private float currentTime;
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        InitializeGame();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Max(currentTime, 0).ToString("F2");

            if (currentTime <= 0)
            {
                EndGame(false);
            }
        }
    }


    public void InitializeGame()
    {
        SceneManager.LoadScene("SampleScene Seungsoo");
        Player.Instance.RestartSeungsoo();
        targetScore = Random.Range(50, 101); // 50에서 100 사이의 랜덤 점수
        timeLimit = targetScore * 0.5f; // 점수에 비례한 시간 제한 
        currentScore = 0;
        currentTime = timeLimit;
        
        targetScoreText.text = "Target Score: " + targetScore;
        scoreText.text = "Score: " + currentScore;
        timeText.text = "Time: " + currentTime.ToString("F2");

        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore;

        if (currentScore >= targetScore)
        {
            EndGame(true);
        }
    }

    void EndGame(bool win)
    {
        if (win)
        {
            winPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            losePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        
    }
}