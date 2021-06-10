using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drogoskaz_klik : MonoBehaviour
{
    public GameObject lista;

    void OnMouseDown()
    {
        if (Drogowskaz_Trigger.wewnocz)
        {
            string nazwa = this.name;
            int numermapy;
            var numer = nazwa.Split('-');
            if (numer.Length < 2)
            {
                numermapy = Hero_stats.ukonczone.Length;
                Debug.Log("niewłaściwa nazwa buttona lol");
            }
            else
            {
                try
                {
                    numermapy = int.Parse(numer[1]);
                    if (Hero_stats.ukonczone[numermapy] == 0)
                    {
                        Hero_stats.maxHlth++;
                        PlayerPrefs.SetInt("maxHlth", Hero_stats.maxHlth);
                        Hero_stats.nme_speed += 0.4f;
                        PlayerPrefs.SetFloat("nme_speed", Hero_stats.nme_speed);
                    }
                    Hero_stats.ukonczone[numermapy] = 1;
                    PlayerPrefs.SetInt("ukonczony" + numermapy, 1);
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                    numermapy = Hero_stats.ukonczone.Length;
                }
            }
            string ukonczonepoziomy="";
            for(int i=0; i<Hero_stats.ukonczone.Length; i++)
            {
                ukonczonepoziomy += i + ": " + Hero_stats.ukonczone[i] + "\n";
            }
            Debug.Log("Ukończone poziomy:\n" + ukonczonepoziomy);
            lista.SetActive(true);
        }
    }
}
