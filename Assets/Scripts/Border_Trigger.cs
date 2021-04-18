using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border_Trigger : MonoBehaviour
{
    public GameObject tekst;
    public GameObject dymek;
    public GameObject postac;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if(other.name=="Szkity_collider")
        dymek.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.name);

        if (other.name == "Szkity_collider")
            dymek.SetActive(true);
    }
}
