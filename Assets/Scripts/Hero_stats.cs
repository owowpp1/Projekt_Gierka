using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero_stats : MonoBehaviour
{
    public static GameObject hero;
    public static GameObject napis;
    public static GameObject wyburScen;
    public static Animator animacja;

    //[Range(0, 4)] [SerializeField] public float set_nme_spd = 1f;
    //[Range(0, 20)] [SerializeField] public int maxHealth = 3;

    public static int Facing;  //1=left, -1=right
    public static bool ded = false;
    public static bool kliknol = false;
    public static bool czyMozna = false;
    public static float nme_speed;
    public static float def_nme_spd;
    public static int maxHlth;
    public static int healthTravel = 450;
    public static int currHealth;
    public static bool vulnerable = true;
    public static int bos_hp;
    public static int[] ukonczone=new int[10];

    void Start()
    {
        hero = GameObject.Find("/hero");
        napis = GameObject.Find("ĆmierćNapis");
        wyburScen = GameObject.Find("WyburScen");
        napis.SetActive(false);
        napis.transform.Find("Zdechłeś").gameObject.SetActive(true);
        wyburScen.SetActive(false);
        wyburScen.transform.Find("Canvas").gameObject.SetActive(true);
        animacja=hero.GetComponent<Animator>();

        for(int i=0; i<ukonczone.Length; i++)
        {
            ukonczone[i]=PlayerPrefs.GetInt("ukonczony" + i, 0);
        }
        nme_speed = PlayerPrefs.GetFloat("nme_speed", 1f);
        def_nme_spd = nme_speed;
        maxHlth = PlayerPrefs.GetInt("maxHlth", 5);
        currHealth = PlayerPrefs.GetInt("currHealth", maxHlth);
        bos_hp = PlayerPrefs.GetInt("bos_hp", 10);
        

        //nme_speed = set_nme_spd;
        //def_nme_spd = set_nme_spd;
        //maxHlth = maxHealth;
        //currHealth = maxHealth;
    }

}
