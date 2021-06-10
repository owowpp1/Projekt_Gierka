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

        Invoke("kliknij", 0.2f);
    }
    void kliknij()
    {
        attack_box.SetActive(true);
        Invoke("odkliknij", 0.5f);
        Soundz.GrajDzwiek("ciach");
    }
    void odkliknij()
    {
        attack_box.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (Time.time - lastClickTime < catchTime && !Hero_stats.ded)
            {
                Attack();
            }
            lastClickTime = Time.time;
        }
    }
}
