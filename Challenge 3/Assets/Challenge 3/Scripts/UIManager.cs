/*
 * Josh McGrew
 * Assignment 4: Challenge 3
 * game UI manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public PlayerControllerX pScript;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //game not over
        if (!pScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        //lose
        if (pScript.gameOver && !win)
        {
            scoreText.text = "You lose.\nPress R to try again.";
        }

        //win
        if (score >= 10)
        {
            pScript.gameOver = true;
            win = true;
            scoreText.text = "You win.\nPress R to try again.";
        }

        //restarting
        if (pScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
