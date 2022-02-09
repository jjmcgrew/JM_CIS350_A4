/*
 * Josh McGrew
 * Assignment 4: Prototype 3
 * UI manager
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public PlayerController playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        //display score until game over
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        //loss condition: hit obstacle
        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "YOU LOSE\nPress R to try again.";
        }

        //win condition: 10 points
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            //stop player from running

            scoreText.text = "YOU WIN\nPress R to try again.";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
