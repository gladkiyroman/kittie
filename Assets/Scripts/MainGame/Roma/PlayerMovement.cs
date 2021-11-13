using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject toDestroy;
    public GameObject WrongPopUp;
    public bool isPlayerWithinZone = false;
    Vector2 movement;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (LevelController.paused == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (movement.x > 0)
        {
            anim.SetInteger("speed", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (movement.y > 0)
        {
            anim.SetInteger("speed", 1);
            
        }
        else if (movement.x < 0)
        {
            anim.SetInteger("speed", 1);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        } 
            else if(movement.y < 0)
        {
            anim.SetInteger("speed", 1);
        }
        else
        {
            anim.SetInteger("speed", -1);
        }

       
        


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
        isPlayerWithinZone = true;

    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(toDestroy);
  
            isPlayerWithinZone = false;
    }
}
