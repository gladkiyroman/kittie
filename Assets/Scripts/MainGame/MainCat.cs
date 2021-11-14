using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCat : MonoBehaviour
{
    public AudioSource audio;
    public GameObject mini;
    private void Awake()
    {
        GameObject.Find("GameOver").GetComponent<Animator>().enabled = false;

        LevelController.paused = false;
        LevelController.escaped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            //GameObject.Find("SceneCoverMainGame").GetComponent<Animator>().SetTrigger("endScene");
            //GameObject.Find("GameOver").GetComponent<Animator>().enabled = true;
            //mini.GetComponent<Minigame>().gameOver();
            //GameObject.Find("ButtonGameOver").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            StartCoroutine(endGame());
        }
    }

    IEnumerator endGame()
    {
        audio = GameObject.Find("AudioWrong").GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

}
