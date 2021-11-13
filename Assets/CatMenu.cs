using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMenu : MonoBehaviour
{
    Animator anim;
    private Vector3 mousePosition;
    public float moveSpeed = 0.01f;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Vector3 tempScale = transform.localScale;
        anim.SetTrigger("run");
    }

    // Update is called once per frame
    void Update()
    {
        
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
