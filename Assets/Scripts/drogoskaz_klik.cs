using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drogoskaz_klik : MonoBehaviour
{
    public GameObject lista;

    void OnMouseDown()
    {
        Debug.Log("Klik");
        if (Drogowskaz_Trigger.wewnocz)
        {
            lista.SetActive(true);
        }
    }
}
