using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    Animator animD, animU, animL, animR;


    public static int days = 0;

    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;



    public static int lossCounter = 3;
    public int arrowsNum = 4;
    public static int miniGameLength = 4;

    public static float speed = 2.5f;
    public GameObject[] arrows = new GameObject[4];
    GameObject selectedArrow;
    public static GameObject spawned;


    void Start()
    {
        if (GameObject.Find("GameOver") != null)
        {
            GameObject.Find("GameOver").GetComponent<Animator>().enabled = false;
        }
        arrowsNum = miniGameLength;
        lossCounter = 3;
        GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = false;
        StartCoroutine(startDelay());


    }

    // Update is called once per frame
    void Update()
    {
        if (spawned != null)
        {
            moveArrow();
            // ENABLE COLLISION after checking the arrow
            if (spawned.transform.position.x <= 0.2f)
            {
                spawned.GetComponent<BoxCollider2D>().enabled = true;
            }

            if(lossCounter == 3)
            {
                heart.SetActive(true);
                heart1.SetActive(true);
                heart2.SetActive(true);
            }
            else if (lossCounter == 2)
            {
                heart2.SetActive(false);
            }
            else if (lossCounter == 1)
            {
                heart1.SetActive(false);
            }
            else if (lossCounter == 0)
            {
                heart.SetActive(false);
            }
        }
        GameObject.Find("GameOver").GetComponent<Text>().text = "Game Over" + "\n" + "Day: " + Minigame.days.ToString();
    }

    void spawnArrow()
    {
        int arrowIndex = Random.Range(0, arrows.Length);
        selectedArrow = arrows[arrowIndex];
        spawned = Instantiate(selectedArrow, GameObject.FindGameObjectWithTag("arrowSpawner").transform.position, Quaternion.identity);
    }
    void moveArrow()
    {
        spawned.transform.position = Vector3.MoveTowards(spawned.transform.position, GameObject.FindGameObjectWithTag("arrowDestination").transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("arrowUp"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Success");
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animU = GameObject.FindGameObjectWithTag("arrowUp").GetComponent<Animator>();
                animU.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                miniGameFail();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animU.enabled = true;
                animU.SetTrigger("miss");
                
            }
        }

        if (collision.gameObject.CompareTag("arrowDown"))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Success");
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animD = GameObject.FindGameObjectWithTag("arrowDown").GetComponent<Animator>();
                animD.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                miniGameFail();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animD.enabled = true;
                animD.SetTrigger("miss");
               

            }
        }

        if (collision.gameObject.CompareTag("arrowRight"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Success");
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animR = GameObject.FindGameObjectWithTag("arrowRight").GetComponent<Animator>();
                animR.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                miniGameFail();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animR.enabled = true;
                animR.SetTrigger("miss");
                

            }
        }


        if (collision.gameObject.CompareTag("arrowLeft"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Success");
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animL = GameObject.FindGameObjectWithTag("arrowLeft").GetComponent<Animator>();
                animL.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                miniGameFail();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animL.enabled = true;
                animL.SetTrigger("miss");
                


            }
        }
    }

    IEnumerator startMiniGame(float time)
    {
        while (arrowsNum >= 0)
        {
                arrowsNum -= 1;
                spawnArrow();
                yield return new WaitForSeconds(time);

            if (animD != null) 
            { 
                animD.enabled = false; 
            }
            if (animU != null)
            {
                animU.enabled = false;
            }
            if (animL != null)
            {
                animL.enabled = false;
            }
            if (animR != null)
            {
                animR.enabled = false;
            }

            if (arrowsNum == -1 && lossCounter > 0)
            {
                GameObject.Find("SceneCover").GetComponent<Animator>().SetTrigger("endScene");
                GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = false;
                // HARDER
                days += 1;
                miniGameLength += 1;
                speed += 0.5f;
                itemGenerator.speed += 5f;
                //HARDER
                SceneManager.LoadScene(0);

            }
        }
    }

    public void gameOver()
    {
        if (lossCounter == 0)
        {
            arrowsNum = -1;
            Debug.Log("You lost!");
            GameObject.Find("SceneCover").GetComponent<Animator>().SetTrigger("endScene");
            GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = false;
            GameObject.Find("GameOver").GetComponent<Animator>().enabled = true;
        }
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = true;
        StartCoroutine(startMiniGame(3));
    }

    public void miniGameFail()
    {
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("fail");
        StartCoroutine(GameObject.Find("MainCam").GetComponent<CamShake>().shake(.3f, .05f));
        lossCounter -= 1;
        gameOver();
        Debug.Log("Fail");

    }



}//class














