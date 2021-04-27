using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_stats : MonoBehaviour
{
    public static GameObject hero;
    public static GameObject napis;

    [Range(0, 4)] [SerializeField] public float set_nme_spd = 1f;

    public static bool Facing;  //0=left, 1=right
    public static bool ded = false;
    public static bool kliknol = false;
    public static bool czyMozna = false;
    public static float nme_speed;
    public static float def_nme_spd;

    void Start()
    {
        hero = GameObject.Find("/hero");
        napis = GameObject.Find("ĆmierćNapis");
        napis.SetActive(false);

        nme_speed = set_nme_spd;
        def_nme_spd = set_nme_spd;
    }

}
