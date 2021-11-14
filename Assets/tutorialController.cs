using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour
{
    public int tutor_count = 0;
    public GameObject tutor_text;
    public GameObject tutor_image_cat;
    public GameObject tutor_image_pl;
    public GameObject tutor_text_pl;


    public GameObject levelCtrl;

    public GameObject cover;

    public GameObject btns;

    public static bool tutored= false;

    // Start is called before the first frame update
    void Start()
    {
        btns.SetActive(false);
        cover.SetActive(false);
        levelCtrl.GetComponent<LevelController>().enabled = false;
        tutor_image_pl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tutor1();
    }



    void tutor1()
    {
        Time.timeScale = 0;
        if (tutor_count == 0)
        {

                tutor_text.GetComponent<Text>().text = "ВИХОДЖУ НА ПОЛЮВАННЯ ЗА НЕБЕЗПЕЧНИМИ РЕЧИМА!";
                tutor_count += 1;
            
        }
        else if(tutor_count == 1)
        {
            if (Input.anyKeyDown)
            {
                tutor_text.GetComponent<Text>().text = "НЕ ЗАВАЖАЙ МЕНІ, ЛЮДИНО!";
                tutor_count += 1;
            }
        }
        else if (tutor_count == 2)
        {
            if (Input.anyKeyDown)
            {
                tutor_image_pl.SetActive(true);
                tutor_image_cat.SetActive(false);
                tutor_text_pl.GetComponent<Text>().text = "КУДИ ПОДІВАВСЯ ТОЙ КІТ?";
                tutor_count += 1;
            }
        }
        else if(tutor_count == 3)
        {
            if (Input.anyKeyDown)
            {
                
                tutor_text_pl.GetComponent<Text>().text = "О НІ! МОЇ РЕЧІ!";
                tutor_count += 1;
                btns.SetActive(true);
            }
        }
        else if(tutor_count == 4)
        {
            if (Input.anyKeyDown)
            {
                tutor_image_pl.SetActive(false);
                Time.timeScale = 1;
                levelCtrl.GetComponent<LevelController>().enabled = true;
                cover.SetActive(true);
                btns.SetActive(false);
                gameObject.SetActive(false);
                tutored = true;
            }
        }
    }

}
