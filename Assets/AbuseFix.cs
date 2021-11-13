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

                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animU.enabled = true;
                    animU.SetTrigger("miss");
 
            }

            if (collision.gameObject.CompareTag("arrowDown"))
            {

                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animD.enabled = true;
                    animD.SetTrigger("miss");


             }

            if (collision.gameObject.CompareTag("arrowRight"))
                {
                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animR.enabled = true;
                    animR.SetTrigger("miss");


                }

            if (collision.gameObject.CompareTag("arrowLeft"))
            {

                m_game.miniGameFail();
                    collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    animL.enabled = true;
                    animL.SetTrigger("miss");
            }
           
        }
    }
}
