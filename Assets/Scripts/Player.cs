using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public GameObject player;
    [SerializeField] private float xMovement;
    [SerializeField] private float speed;
    [SerializeField] private GameObject leftButton;
    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject gameoverpanel;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private TextMeshProUGUI scoreTXT;
    [SerializeField] private TextMeshProUGUI lifeTXT;

    public static int score = 0;
    private bool dead = false;
    private bool paused = false;
    
    public int health = 3;

    private void Start()
    {
        score = 0;
        Time.timeScale = 1;
        targetPos = player.transform.position;

        if (!DeviceSetings.mobile)
        {
            leftButton.SetActive(false);
            rightButton.SetActive(false);
        }
        if (DeviceSetings.mobile)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }
    }

    void Update()
    {

        lifeTXT.text = "Life : " + health.ToString();
        scoreTXT.text = "Score : " + score.ToString();

        if (Input.GetKeyDown(KeyCode.A) && player.transform.position.x > -2f)
        {
            targetPos = new Vector2(transform.position.x - xMovement, transform.position.y);
           
        }
        else if (Input.GetKeyDown(KeyCode.D) && player.transform.position.x < 2f)
        {
            targetPos = new Vector2(transform.position.x + xMovement, transform.position.y);
        }
        
        if (targetPos.x < -2f)
        {
            targetPos.x = -2f;
        }
        if (targetPos.x > 2f)
        {
            targetPos.x = 2f;
        }
        player.transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (health <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!dead)
            {
                if (paused)
                {
                    Time.timeScale = 1;
                    pausePanel.SetActive(false);
                }

                if (!paused)
                {
                    Time.timeScale = 0;
                    pausePanel.SetActive(true);
                }
                
            }
        }
    }

    public void moveleft()
    {
        if (player.transform.position.x > -2f)
        {
            targetPos = new Vector2(transform.position.x - xMovement, transform.position.y);
           
        }
    }

    public void moveright()
    {
         if (player.transform.position.x < 2f) 
         {
            targetPos = new Vector2(transform.position.x + xMovement, transform.position.y); 
         }
    }

    void GameOver()
    {
        dead = true;
        Time.timeScale = 0;
        gameoverpanel.SetActive(true);
    }

   public void replay()
   {
       dead = false;
        SceneManager.LoadScene(2);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    
}

