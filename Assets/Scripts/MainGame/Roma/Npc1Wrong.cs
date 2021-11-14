using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1Wrong : MonoBehaviour
{
    public AudioSource audio;
    public GameObject toDestroy;
    public GameObject enterbtn2;
    public bool isPlayerWithinZone = false;

    //private GameObject toDestroy;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("AudioWrong").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerWithinZone && Input.GetKeyDown(KeyCode.Return))
        {
            audio.Play();
            Debug.Log("Wrong item!");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        toDestroy = Instantiate(enterbtn2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        if (collider.tag == "Player")
        {
            isPlayerWithinZone = true;
        }
    }


    //IEnumerator watchForKeyPress()
    //{
    //    while (isPlayerWithinZone)
    //    {
    //        if (Input.GetKey(KeyCode.Return))
    //        {
    //            // SceneManager.LoadScene("nextDoorSceneName");
    //            Debug.Log("Starting minigame!");
    //        }
    //        yield return null;
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(toDestroy);
        if (collider.tag == "Player")
        {
            isPlayerWithinZone = false;
        }
    }

}
