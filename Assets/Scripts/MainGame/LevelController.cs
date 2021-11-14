using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject GameOver;
    public static bool paused;
    public bool escaped = false;
    private void Start()
    {
        paused = false;
    }
    void Update()
    {
        if (paused == false && escaped == false)
        {
           Time.timeScale = 1;
            GameOver.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            GameOver.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escaped = !escaped;
            paused = !paused;
        }

        pause_menu();

        GameObject.Find("Days").GetComponent<Text>().text = "Hours: " + Minigame.days.ToString();

        
        GameOver.GetComponent<Text>().text = "Game Over" + "\n" + "Hours: " + Minigame.days.ToString();
        
    }


    private void pause_menu()
    {
        if (paused == true && escaped == true)
        {
            pauseObject.SetActive(true);
        }
        else if (paused == false && escaped == false)
        {
            pauseObject.SetActive(false);
        }
    }

    public void resume()
    {
        escaped = false;
        paused = false;
        Time.timeScale = 1;
        pauseObject.SetActive(false);
        Debug.Log("Resume!!!!");
    }

    public void exitGame()
    {
        Application.Quit();
        escaped = false;
        paused = false;
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        escaped = false;
        paused = false;
        Time.timeScale = 1;
    }




















}//class
