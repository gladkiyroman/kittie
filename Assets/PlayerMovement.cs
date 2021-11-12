using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject toDestroy;
    public GameObject WrongPopUp;
    public bool isPlayerWithinZone = false;
    Vector2 movement;

    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (isPlayerWithinZone && Input.GetKeyDown(KeyCode.Return))
        {
            toDestroy = Instantiate(WrongPopUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }

    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Checking");
        if (collider.tag == "WrongObject")
        {
            isPlayerWithinZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(toDestroy);
        if (collider.tag == "WrongObject")
        {
            isPlayerWithinZone = false;
        }
    }
}
