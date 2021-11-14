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
    public static bool escaped = false;
    private void Start()
    {
        paused = false;
        escaped = false;
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

        GameObject.Find("Days").GetComponent<Text>().text = "ГОДИНИ: " + Minigame.days.ToString();

        
        GameOver.GetComponent<Text>().text = "ГРУ ЗАВЕРШЕНО" + "\n" + "ГОДИНИ: " + Minigame.days.ToString();
        
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
       
    }

    public void exitGame()
    {
        escaped = false;
        paused = false;
        Time.timeScale = 1;
        tutorialController.tutored = false;
        Application.Quit();
        
    }

    public void mainMenu()
    {

        SceneManager.LoadScene(0);
        escaped = false;
        paused = false;
        Time.timeScale = 1;
    }




















}//class
