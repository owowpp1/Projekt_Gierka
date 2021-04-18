using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drogowskaz_Trigger : MonoBehaviour
{
 
    public static bool wewnocz=false;
    public GameObject lista;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
            wewnocz = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.name);

        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
        {
            wewnocz = false;
            lista.SetActive(false);
        }
    }
}
