﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour {

    [SerializeField] Ball ball1;
    [SerializeField] Paddle paddle1;
    [SerializeField] GameObject win;
    [SerializeField] int lives = 2;
    [SerializeField] TextMeshProUGUI livesText;
    public bool lostBall = false;
    public bool hasStarted = false;

    // Use this for initialization
    void Start () 
    {
        livesText.text = lives.ToString();
        Cursor.visible = false;
    }



    // Update is called once per frame
    void Update () 
    {
        var foundBlocks = FindObjectsOfType<Block>();
        if (foundBlocks.Length == 0)
        {
            Destroy(ball1.GetComponent<Rigidbody2D>());
            paddle1.GetComponent<Paddle>().enableMovement = false;
            win.SetActive(true);
            Cursor.visible = true;
        }

        if (lostBall == true)
        {
            if (lives == 0)
            {
                Cursor.visible = true;
                SceneManager.LoadScene("Game Over");
            }
            else 
            {
                lives--;
                livesText.text = lives.ToString();
                paddle1.GetComponent<Paddle>().enableMovement = false;
                ball1.GetComponent<Rigidbody2D>().Sleep();
                ball1.GetComponent<Ball>().MoveBallToPaddle();
                hasStarted = false;
                ball1.GetComponent<Rigidbody2D>().WakeUp();
                paddle1.GetComponent<Paddle>().enableMovement = true;
            }
            lostBall = false;
        }
	}
}