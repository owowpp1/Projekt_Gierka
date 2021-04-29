using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dabulklik : MonoBehaviour
{
   
    public Animator animacja;
    private float lastClickTime;
    public float catchTime = 0.25f;
    public GameObject attack_box;

    void Attack()
    {
        animacja.SetTrigger("atacc");


        //Hero_stats.kliknol = true;

        Invoke("kliknij", 0.2f);
    }
    void kliknij()
    {
        attack_box.SetActive(true);
        Invoke("odkliknij", 0.5f);
    }
    void odkliknij()
    {
        //Hero_stats.kliknol = false;


        attack_box.SetActive(false);
    }
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }*/
        if (Input.GetButtonDown("Fire1"))
        {

            if (Time.time - lastClickTime < catchTime && !Hero_stats.ded)
            {
                //double click
                //print("Double click");
                Attack();
                //SceneManager.LoadScene("Do_testów");
            }
            else
            {
                //normal click
               
            }
            lastClickTime = Time.time;
        }
    }
}
