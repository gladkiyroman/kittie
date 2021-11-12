using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCat : MonoBehaviour
{

    public void reposition()
    {
        transform.position = new Vector2(transform.position.x, -2.699f);
    }

    public void setIdle()
    {
        GameObject.Find("MiniGameCat").GetComponent<Animator>().SetTrigger("idle");
    }

}
