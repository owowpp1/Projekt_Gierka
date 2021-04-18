using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zabijanko : MonoBehaviour
{
    public Animator animacja;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
            Hero_stats.czyMozna = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
            Hero_stats.czyMozna = false;
    }
    void Update()
    {
        if (Hero_stats.czyMozna && Hero_stats.kliknol)
        {
            animacja.SetBool("ded", true);

            Hero_stats.czyMozna = false;
            Hero_stats.kliknol = false;

            Invoke("wyloncz", 1.3f);

        }

    }
    void wyloncz()
    {

        this.gameObject.SetActive(false);
    }
}
