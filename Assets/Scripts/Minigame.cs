using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    Animator animD, animU, animL, animR;

    public static int lossCounter = 2;
    public int arrowsNum = 4;

    public float speed = 1f;
    public GameObject[] arrows = new GameObject[4];
    GameObject selectedArrow;
    public static GameObject spawned;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        StartCoroutine(startDelay());
        StartCoroutine(startMiniGame(3f));
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned != null)
        {
            moveArrow();
        }
        // ENABLE COLLISION after checking the arrow
        if (spawned.transform.position.x <= 0.2f)
        {
            spawned.GetComponent<BoxCollider2D>().enabled = true;
        }
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
                animU = GameObject.FindGameObjectWithTag("arrowUp").GetComponent<Animator>();
                animU.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Fail");
                animU.enabled = true;
                animU.SetTrigger("miss");
                lossCounter -= 1;
                gameOver();
            }
        }

        if (collision.gameObject.CompareTag("arrowDown"))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Success");
                animD = GameObject.FindGameObjectWithTag("arrowDown").GetComponent<Animator>();
                animD.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Fail");
                animD.enabled = true;
                animD.SetTrigger("miss");
                lossCounter -= 1;
                gameOver();
            }
        }

        if (collision.gameObject.CompareTag("arrowRight"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Success");
                animR = GameObject.FindGameObjectWithTag("arrowRight").GetComponent<Animator>();
                animR.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Fail");
                animR.enabled = true;
                animR.SetTrigger("miss");
                lossCounter -= 1;
                gameOver();
            }
        }


        if (collision.gameObject.CompareTag("arrowLeft"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Success");
                animL = GameObject.FindGameObjectWithTag("arrowLeft").GetComponent<Animator>();
                animL.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Fail");
                animL.enabled = true;
                animL.SetTrigger("miss");
                lossCounter -= 1;
                gameOver();
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

            if (arrowsNum == -1)
            {
                GameObject.Find("SceneCover").GetComponent<Animator>().SetTrigger("endScene");
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
        }
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1f);
    }



}//class














