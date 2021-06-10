using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_triger : MonoBehaviour
{

    public static bool wesrodku = false;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
            wesrodku = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.name);

        if (other.name == "Klata_collider" || other.name == "Szkity_collider")
        {
            wesrodku = false;
           
        }
    }
}
