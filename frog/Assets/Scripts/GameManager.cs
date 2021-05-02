using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject instructionAndScore;
    public GameObject pauseScreen;
    public PlayerController playerController;
    public GameObject startPosition;
    public Lives livesHolder;

    public Collectible[] spawnables;
    public int[] rarities;
    public int[] raritySums;

    public Obstacle[] obstacles;
    public int[] difficulty;

    public int Score;
    public int Lives;
    bool isPaused = false;
    bool isGameOver = false;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        raritySums = new int[rarities.Length];

        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < rarities.Length; i++)
        {
            weightSum += rarities[i];
            raritySums[i] = weightSum;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                PauseGame();
            }

            else if (!isPaused && Input.GetAxisRaw("Vertical") > 0.5) {
                playerController.Jump();
            }

            else if (!isPaused && Input.GetKeyDown("space")) {
                playerController.TryToShootTongue();
            }
        }
        else if (Input.GetKeyDown("space")) {
            GameOver();
        }
    }

    void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused) {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        pauseScreen.SetActive(isPaused);
        instructionAndScore.SetActive(!isPaused);
        pauseScreen.GetComponentInChildren<Score>().AddScore();
    }

    void GameOver ()
    {
        isGameOver = !isGameOver;
        if (isGameOver) {
            Time.timeScale = 0;
            playerController.ShootTongue(false);
            SoundManager.Instance.PlaySound(soundEffects.gameOver);
        }
        else {
            Time.timeScale = 1;
            NewGame();
            playerController.transform.position = startPosition.transform.position;
        }
        playerController.GameOver(isGameOver);
        instructionAndScore.SetActive(!isGameOver);
        gameOverScreen.SetActive(isGameOver);
        gameOverScreen.GetComponentInChildren<Score>().AddScore();
    }

    void NewGame() {
        Score = 0;
        Lives = 3;
    }

    public void OnHit() {
        Lives--;
        livesHolder.LoseLife();
        if (Lives == 0) {
            GameOver();
        }
    }

    void OnMouseDown()
    {
        ScreenCapture.CaptureScreenshot("myCoverImage");
    }

    public void OnHeartCollect() {
        Lives++;
        livesHolder.GainLife();
    }

}
