using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject StartButton;
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI scoreText;
    public float enemyGenTimeGap;
    public int enemyPerWave = 1;
    public AudioSource playerAudioSource;
    public AudioClip gamePrepMusic;
    public AudioClip inGameMusic;
    public AudioSource gameOverAudioSource;

    private EnemyGenerator enemyGenerator;
    private Timer timer;
    private int userScore;
    //用来记录敌人间隔时间。
    private float _enemyGenTimer;
    //标记游戏是否开始。
    private bool gameStarted = false;


    private void Awake()
    {
        //链接需要的componnet。
        timer = this.GetComponent<Timer>();
        enemyGenerator = FindObjectOfType<EnemyGenerator>();

        //游戏初始状态。
        StartButton.SetActive(true);
        startButtonText.text = "START";
        UpdateScoreDisplay();


    }

    private void Update()
    {
        if (gameStarted)
        {
            _enemyGenTimer += Time.deltaTime;
            if (_enemyGenTimer >= enemyGenTimeGap)
            {
                _enemyGenTimer = 0;
                enemyGenerator.GenerateEnemy(enemyPerWave);
            }
        }
    }

    public void StartGame()
    {
        //循环播放游戏开始音乐。
        playerAudioSource.clip = inGameMusic;
        playerAudioSource.Play();

        //重置分数
        userScore = 0;
        UpdateScoreDisplay();
        //开始计时器
        timer.StartTimer();
        //隐藏开始按钮
        StartButton.SetActive(false);
        //收听计时器结束action。
        timer.OnTimerOver += GameOver;
        //重置敌人间隔时间。
        _enemyGenTimer = 0;
        //标记游戏开始。
        gameStarted = true;
    }

    //游戏结束。
    public void GameOver()
    {
        //播放游戏结束。
        gameOverAudioSource.Play();

        //循环播放准备音乐。
        playerAudioSource.clip = gamePrepMusic;
        playerAudioSource.Play();

        //标记游戏结束。
        gameStarted = false;
        StartButton.SetActive(true);
        startButtonText.text = "RESTART";
    }

    public void addScore(int scoreToAdd)
    {
        userScore += scoreToAdd;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "SCORE:\n" + userScore;
    }
}
