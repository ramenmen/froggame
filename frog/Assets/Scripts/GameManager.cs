using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject instructionAndScore;
    public GameObject instruction;
    public GameObject pauseScreen;
    public PlayerController playerController;
    public GameObject startPosition;
    public Lives livesHolder;

    public Collectible[] spawnables;
    public int[] rarities;
    public int[] raritySums;

    public GameObject[] obstacles;
    public int[] difficulty;
    public int[] difficultySums;

    public int Score;
    public int Lives;
    bool isPaused = false;
    bool isGameOver = false;
    bool isStarted = false;

    public AudioSource BGM;
    public AudioSource AmbientSound;
    public float BGM_play_from;

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
        int weightSum = 0;
        for (int i = 0; i < rarities.Length; i++)
        {
            weightSum += rarities[i];
            raritySums[i] = weightSum;
        }

<<<<<<< HEAD
        BGM.Play();
=======
        difficultySums = new int[difficulty.Length];
        weightSum = 0;
        for (int i = 0; i < difficulty.Length; i++)
        {
            weightSum += difficulty[i];
            difficultySums[i] = weightSum;
        }
>>>>>>> 569711bbc09e4147a47062977d45b902be92a8b1
    }

    // Start is called before the first frame update
    void Start()
    {
        StartScreen();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (!isGameOver) {
            if (!isPaused && !BGM.isPlaying) {
                BGM.time = BGM_play_from;
                BGM.Play();
                Debug.Log("BGM time/play_from: " + BGM.time + " " + BGM_play_from);
            }

=======
        if (playerController.transform.position.x > startPosition.transform.position.x) {
            instruction.SetActive(false);
        }
        if (!isStarted) {
            if (Input.GetKeyDown("space")) {
                NewGame();
                isStarted = true;
            }
        }
        else if (!isGameOver) {
>>>>>>> 569711bbc09e4147a47062977d45b902be92a8b1
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
            GameOver(false);
        }
        // Debug.Log("BGM time: " + BGM.time);
    }

    void PauseGame()
    {
        isPaused = !isPaused;

        if (BGM.isPlaying) {
            BGM_play_from = BGM.time;
            BGM.Stop();
            AmbientSound.Play();
            Debug.Log("BGM time/play_from: " + BGM.time + " " + BGM_play_from);
        }
        
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

    void GameOver (bool gameOver)
    {
<<<<<<< HEAD
        isGameOver = !isGameOver;

        if (BGM.isPlaying) {
            BGM.Stop();
            AmbientSound.Play();
        }

=======
        isGameOver = gameOver;
>>>>>>> 569711bbc09e4147a47062977d45b902be92a8b1
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
        Time.timeScale = 1;
        instructionAndScore.SetActive(true);
        startScreen.SetActive(false);
        playerController.isGameStarted = true;
        livesHolder.Restart();
    }

    void StartScreen() {
        startScreen.SetActive(true);
        instructionAndScore.SetActive(false);
        //Time.timeScale = 0;
    }

    public void OnHit() {
        Lives--;
        livesHolder.LoseLife();
        if (Lives <= 0) {
            GameOver(true);
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
