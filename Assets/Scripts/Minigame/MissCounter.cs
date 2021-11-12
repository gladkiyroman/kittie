using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    Minigame miniGame;
    private void Awake()
    {
        miniGame = GameObject.Find("arrowCheck").GetComponent<Minigame>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        miniGame.miniGameFail();
        collision.GetComponent<Animator>().enabled = true;
        collision.GetComponent<Animator>().SetTrigger("miss");
    }
}
