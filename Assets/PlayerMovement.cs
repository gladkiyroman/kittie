using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject enterbtn;
    
    Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical"); 
        
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Checking");
        //if (collider.tag == "npc_0")
        //    isPlayerWithinZone = true;
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
    }
}
