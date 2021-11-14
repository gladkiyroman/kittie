using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{

    public List<string> dialogues_CatWins = new List<string>();


    public List<string> dialogues_CatLoses = new List<string>();

    public GameObject cloud;
    public GameObject cloudText;

    Animator animD, animU, animL, animR;


    public static int days = 0;

    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;

    public GameObject playerMini;

    public static int lossCounter = 3;
    public int arrowsNum = 4;
    public static int miniGameLength = 4;

    public static float speed = 2.5f;
    public GameObject[] arrows = new GameObject[4];
    GameObject selectedArrow;
    public static GameObject spawned;


    public GameObject tutor;

    public GameObject menuBtn;


    void Start()
    {
        menuBtn.SetActive(false);
        tutor.SetActive(false);
        int dialogueIndex = Random.Range(0, dialogues_CatWins.Count);
        int dialogueIndexLoss = Random.Range(0, dialogues_CatLoses.Count);
        cloud.SetActive(false);
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
            if (spawned.transform.position.x <= -2f)
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
        GameObject.Find("GameOver").GetComponent<Text>().text = "Game Over" + "\n" + "Hours: " + Minigame.days.ToString();
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
                //GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animU = GameObject.FindGameObjectWithTag("arrowUp").GetComponent<Animator>();
                playerMini.GetComponent<Animator>().SetTrigger("attack");
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
                //GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animD = GameObject.FindGameObjectWithTag("arrowDown").GetComponent<Animator>();
                playerMini.GetComponent<Animator>().SetTrigger("attack");
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
                //GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animR = GameObject.FindGameObjectWithTag("arrowRight").GetComponent<Animator>();
                playerMini.GetComponent<Animator>().SetTrigger("attack");
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
                //GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                playerMini.GetComponent<Animator>().SetTrigger("attack");
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
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("fights");
        yield return new WaitForSeconds(2f);
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("idle");
        yield return new WaitForSeconds(1f);
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
                takeItem();
                // HARDER
                days += 1;
                miniGameLength += 1;
                speed += 0.9f;
                itemGenerator.speed += 20f;
                //HARDER
                StartCoroutine(dialogueLoss());
                StartCoroutine(delayedSceneLoad(2.5f));

            }
        }
    }

    public void gameOver()
    {
        if (lossCounter == 0)
        {
            arrowsNum = 0;
            StartCoroutine(dialogue());
            StartCoroutine(destroyItem());
            
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
        playerMini.GetComponent<Animator>().SetTrigger("damaged");
        lossCounter -= 1;
        gameOver();
        Debug.Log("Fail");

    }

    IEnumerator destroyItem()
    {
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("catWins");
        yield return new WaitForSeconds(2f);
        arrowsNum = -1;
        Debug.Log("You lost!");
        GameObject.Find("SceneCover").GetComponent<Animator>().SetTrigger("endScene");
        GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = false;
        GameObject.Find("GameOver").GetComponent<Animator>().enabled = true;
    }


    public void takeItem()
    {
        if (GameObject.Find("SpawnItem") != null)
        {
            GameObject.Find("SpawnItem").transform.position = new Vector2(playerMini.transform.position.x  -0.6f, playerMini.transform.position.y);
        }
    }


    IEnumerator delayedSceneLoad(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }



    IEnumerator dialogue()
    {
        int dialogueIndex = Random.Range(0, dialogues_CatWins.Count);
        string line = dialogues_CatWins[dialogueIndex];
        cloud.SetActive(true);
        cloudText.GetComponent<Text>().text = line;
        yield return new WaitForSeconds(3f);
        menuBtn.SetActive(true);
        cloud.SetActive(false);
    }

    IEnumerator dialogueLoss()
    {
        int dialogueIndexLoss = Random.Range(0, dialogues_CatLoses.Count);
        string line = dialogues_CatLoses[dialogueIndexLoss];
        cloud.SetActive(true);
        cloudText.GetComponent<Text>().text = line;
        yield return new WaitForSeconds(3f);
        cloud.SetActive(false);
    }


    public void endGameClick()
    {
        SceneManager.LoadScene(0);
    }

    }//class














