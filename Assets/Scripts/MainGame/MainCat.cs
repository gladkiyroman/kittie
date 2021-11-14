using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCat : MonoBehaviour
{
    public GameObject mini;
    private void Awake()
    {
        GameObject.Find("GameOver").GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            GameObject.Find("SceneCoverMainGame").GetComponent<Animator>().SetTrigger("endScene");
            GameObject.Find("GameOver").GetComponent<Animator>().enabled = true;
            mini.GetComponent<Minigame>().gameOver();
        }
    }

}
