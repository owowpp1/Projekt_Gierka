using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_stats : MonoBehaviour
{
    public static GameObject hero;
    public static GameObject napis;
    public static GameObject wyburScen;

    [Range(0, 4)] [SerializeField] public float set_nme_spd = 1f;
    [Range(0, 20)] [SerializeField] public int maxHealth = 3;

    public static int Facing;  //1=left, -1=right
    public static bool ded = false;
    public static bool kliknol = false;
    public static bool czyMozna = false;
    public static float nme_speed;
    public static float def_nme_spd;
    public static int maxHlth;
    public static int healthTravel = 450;
    public static int currHealth;

    void Start()
    {
        hero = GameObject.Find("/hero");
        napis = GameObject.Find("ĆmierćNapis");
        wyburScen = GameObject.Find("WyburScen");
        napis.SetActive(false);
        napis.transform.Find("Zdechłeś").gameObject.SetActive(true);
        wyburScen.SetActive(false);
        wyburScen.transform.Find("Canvas").gameObject.SetActive(true);

        nme_speed = set_nme_spd;
        def_nme_spd = set_nme_spd;
        maxHlth = maxHealth;
        currHealth = maxHealth;
    }

}
