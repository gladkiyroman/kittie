using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowMouse : MonoBehaviour
{
    Animator anim;
    private Vector3 mousePosition;
    public float moveSpeed = 0.01f;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 tempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed*Time.deltaTime);
        if(transform.position == mousePosition)
        {
            anim.SetTrigger("idle");
        }
        else
        {
            anim.SetTrigger("run");
        }

        
    }

    public void startNew()
    {
        SceneManager.LoadScene(1);
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
