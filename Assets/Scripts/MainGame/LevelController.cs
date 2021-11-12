using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Days").GetComponent<Text>().text = "Day: " + Minigame.days.ToString();
        GameObject.Find("GameOver").GetComponent<Text>().text = "Game Over"+"\n"+"Day: " + Minigame.days.ToString();
    }
}
