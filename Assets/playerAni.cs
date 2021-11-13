using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAni : MonoBehaviour
{
    public GameObject cat;
    Animator anim;
    public void setIdle()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
    }
    public void dmgAndsetIdle()
    {
        cat.GetComponent<Animator>().SetTrigger("success");
        anim = GetComponent<Animator>();
        anim.SetTrigger("idle");
    }
}
