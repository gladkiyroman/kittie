using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class anima : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void animate()
    {
        anim.SetTrigger("animate");
    }
    public void loading()
    {
        SceneManager.LoadScene(1);
    }

}
