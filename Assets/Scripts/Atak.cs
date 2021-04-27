using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atak : MonoBehaviour
{
    Animator animacja;
    GameObject drugi;
    Collider2D cmierc;
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.tag == "wruk")
        {
            drugi = other.gameObject;
            animacja=other.GetComponent<Animator>();
            animacja.SetBool("ded", true);
            Hero_stats.nme_speed = 0f;
            //cmierc = other.GetComponent<Collider2D>();
            //cmierc.enabled = false;
            drugi.transform.Find("Ćmierć").gameObject.SetActive(false);

            Invoke("wyloncz", 1.3f);

        }

    }
    void wyloncz()
    {

        drugi.gameObject.SetActive(false);
        Hero_stats.nme_speed = Hero_stats.def_nme_spd;
    }
}
