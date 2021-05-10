using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ćmierć : MonoBehaviour
{
    GameObject tekst;
    GameObject postac;
    public static GameObject healthbar;
    //Transform health;
    private RectTransform pozycja_RT;
    private Vector2 pozycja_pocz;
    private Vector2 pozycja_konc;
    private Vector2 krok;

    private Vector2 pozycjaHelthbaraWys;
    private Vector2 pozycjaHelthbaraSch;

    bool kolizja = true;

    int dmg = 1;

    void Start()
    {
        postac = Hero_stats.hero;
        tekst = Hero_stats.napis;
        healthbar = GameObject.Find("HealthBar");
        pozycja_RT = healthbar.transform.Find("health").GetComponent<RectTransform>();
        pozycja_pocz = pozycja_RT.anchoredPosition;
        pozycja_konc = healthbar.transform.Find("Pozycja_koniec").GetComponent<RectTransform>().anchoredPosition;

        pozycjaHelthbaraWys = healthbar.GetComponent<RectTransform>().anchoredPosition;
        pozycjaHelthbaraSch = GameObject.Find("HelthBar_schowany").GetComponent<RectTransform>().anchoredPosition;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("wykryto lol");
        if (other.name == "Szkity_collider" && kolizja)
        {
            kolizja = false;
            var pozycja = pozycja_RT.anchoredPosition;

            if (this.name == "Lawa") dmg = Hero_stats.currHealth;
            else dmg = 1;

            Hero_stats.currHealth-=dmg;

            krok = new Vector2(0, 0);
            krok.x = (pozycja_konc.x - pozycja_pocz.x);
            krok /= (Hero_stats.maxHlth-1);
            krok *= dmg;

            Vector2 cel = pozycja + krok;

            //Debug.Log("pos: " + pozycja);
            //Debug.Log("cel: " + cel);
            //WysunHB();
            StartCoroutine(przesunPasek(cel, 2));
            //Invoke("SchowajHB", 5);

            if (Hero_stats.currHealth <= 0)
            {
                tekst.SetActive(true);
                Ruch.predkosc = 0f;
                Ruch.progSkok = 2f;
                Hero_stats.ded = true;
                Invoke("respawn", 2);
            }
            Invoke("kolizjatrue", 2);
        }
    }
    void respawn()
    {
        tekst.SetActive(false);
        Hero_stats.ded = false;
        Hero_stats.currHealth = Hero_stats.maxHlth;
        postac.transform.position = Ruch.pozycjaStartowa;
        pozycja_RT.anchoredPosition = pozycja_pocz;
        Ruch.predkosc = 40f;
        Ruch.progSkok = .5f;
        pozycja_RT.anchoredPosition = pozycja_pocz;
        kolizja = true;
    }
    void kolizjatrue()
    {
        kolizja = true;
    }
    public void WysunHB()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            healthbar.GetComponent<RectTransform>().anchoredPosition += (pozycjaHelthbaraWys - healthbar.GetComponent<RectTransform>().anchoredPosition) * t / 1f;
        }
        Debug.Log(healthbar.GetComponent<RectTransform>().anchoredPosition);
    }
    public void SchowajHB()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            healthbar.GetComponent<RectTransform>().anchoredPosition += (pozycjaHelthbaraSch - healthbar.GetComponent<RectTransform>().anchoredPosition) * t / 1f;
        }
        Debug.Log(healthbar.GetComponent<RectTransform>().anchoredPosition);
    }
    public IEnumerator przesunPasek(Vector2 cel, float czas)
    {
        float t = 0f;
        while (t < czas)
        {
            t += Time.deltaTime;
            pozycja_RT.anchoredPosition += (cel - pozycja_RT.anchoredPosition) * t / czas;
            yield return null;
        }

        pozycja_RT.anchoredPosition = cel;
    }

}
