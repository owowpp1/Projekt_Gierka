using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ćmierć : MonoBehaviour
{
    public GameObject tekst;
    public GameObject postac;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("wykryto lol");
        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
        {
            tekst.SetActive(true);
            Ruch.predkosc = 0f;
            Ruch.progSkok = 2f;
            Hero_stats.ded = true;
            Invoke("respawn", 2);
        }
    }
    void respawn()
    {
        tekst.SetActive(false);
        Hero_stats.ded = false;
        postac.transform.position = Ruch.pozycjaStartowa;
        Ruch.predkosc = 40f;
        Ruch.progSkok = .5f;
    }
}
