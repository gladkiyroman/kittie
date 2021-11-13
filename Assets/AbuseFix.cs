using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbuseFix : MonoBehaviour
{
    Animator animD, animU, animL, animR;
    Minigame m_game;
    private void Start()
    {
        m_game = GameObject.Find("arrowCheck").GetComponent<Minigame>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.anyKey)
        {
            if (collision.gameObject.CompareTag("arrowUp"))
            {

                animU = GameObject.FindGameObjectWithTag("arrowUp").GetComponent<Animator>();
                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animU.enabled = true;
                    animU.SetTrigger("miss");
 
            }

            if (collision.gameObject.CompareTag("arrowDown"))
            {
                animD = GameObject.FindGameObjectWithTag("arrowDown").GetComponent<Animator>();
                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animD.enabled = true;
                    animD.SetTrigger("miss");


             }

            if (collision.gameObject.CompareTag("arrowRight"))
                {
                animR = GameObject.FindGameObjectWithTag("arrowRight").GetComponent<Animator>();
                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animR.enabled = true;
                    animR.SetTrigger("miss");


                }

            if (collision.gameObject.CompareTag("arrowLeft"))
            {
                animL = GameObject.FindGameObjectWithTag("arrowLeft").GetComponent<Animator>();
                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animL.enabled = true;
                    animL.SetTrigger("miss");
            }
           
        }
    }
}
