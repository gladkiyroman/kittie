using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatAnimation : MonoBehaviour
{

    private int numAnimations = 0;
    public Animator anim1, anim2, anim3, anim4;
    public Image img1, img2, img3, img4;

    public void start()
    {
        Debug.Log("Pizda1");
    }
    

    public void update()
    {
        if (numAnimations == 0)
        {
            Debug.Log("Pizda");
            anim1.enabled=true;
            img1.enabled = true;
            numAnimations++;
        }
    }
}
