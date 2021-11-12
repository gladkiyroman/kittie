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
    void Start()
    {
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
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("idle");
            }
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
                GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("success");
                animU = GameObject.FindGameObjectWithTag("arrowUp").GetComponent<Animator>();
                animU.enabled = true;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }

            else if (Input.anyKey)
            {
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animU.enabled = true;
                animU.SetTrigger("miss");
                miniGameFail();
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
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animD.enabled = true;
                animD.SetTrigger("miss");
                miniGameFail();

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
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animR.enabled = true;
                animR.SetTrigger("miss");
                miniGameFail();

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
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                animL.enabled = true;
                animL.SetTrigger("miss");
                miniGameFail();


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
                GameObject.Find("MiniGameCat").GetComponent<Animator>().enabled = false;
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
        lossCounter -= 1;
        gameOver();
        Debug.Log("Fail");
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("fail");

    }



}//class














