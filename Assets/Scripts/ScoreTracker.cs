using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private UnityEngine.UI.Text scoreText;

    private int score;

    void Start()
    {
        scoreText = this.gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    private void Update()
    {
        this.scoreText.text = score.ToString();
    }

    public void addScore(int score)
    {
        this.score += score;
    }

}
