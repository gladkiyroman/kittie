using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject GameOver;
    public static bool paused = false;
    private void Start()
    {
        paused = false;
    }
    void Update()
    {
        if (paused == false)
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
            paused = !paused;
        }

        pause_menu();

        GameObject.Find("Days").GetComponent<Text>().text = "Day: " + Minigame.days.ToString();
        GameObject.Find("GameOver").GetComponent<Text>().text = "Game Over"+"\n"+"Day: " + Minigame.days.ToString();
    }


    private void pause_menu()
    {
        if (paused == true)
        {
            pauseObject.SetActive(true);
        }
        else if (paused == false)
        {
            pauseObject.SetActive(false);
        }
    }

    public void resume()
    {
        paused = false;
        Time.timeScale = 1;
        pauseObject.SetActive(false);
        Debug.Log("Resume!!!!");
    }

    public void exitGame()
    {
        Application.Quit();
        paused = false;
        Time.timeScale = 1;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        paused = false;
        Time.timeScale = 1;
    }




















}//class
