using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int targetScore;
    public int growthRate;
    public string beforeText = "";

    // Start is called before the first frame update
    void OnEnable()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score != targetScore) {
            AnimateScore();
        }
        scoreText.text = beforeText + score.ToString();
    }

    public void AddScore() {
        targetScore = GameManager.Instance.Score;
    }

    void AnimateScore() {
        if (targetScore - score > growthRate) {
            score += growthRate;
        }
        else {
            score = targetScore;
        }
    }
}
