using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{

    public CharacterController2D ruch;
    public Joystick kontroler;

    public static Vector3 pozycjaStartowa;

    public static float predkosc = 40f;
    public static float ruchwbok;
    public static int delajskok =20;
    public static int delajkuc =20;
    public static float progSkok = .5f;
    public static bool czyskok = false;
    public static bool przykuc = false;


    void Start()
    {
        //Debug.Log("start");
        pozycjaStartowa = transform.position;
        //Debug.Log(pozycjaStartowa);
    }
    void FixedUpdate()
    {
        //predkosc = 0;
        //if (RuchPrzyciski.czywlewo)
        //{
        //    predkosc = -40;
        //    RuchPrzyciski.czywlewo = false;
        //}
        //if (RuchPrzyciski.czywprawo) 
        //{ 
        //    predkosc = 40;
        //    RuchPrzyciski.czywprawo = false;
        //}

        //ruch.Move(predkosc*Time.fixedDeltaTime, przykuc, RuchPrzyciski.czyskok);
        //RuchPrzyciski.czyskok = false;
        //przykuc = false;
        //if (RuchPrzyciski.delaj<30) RuchPrzyciski.delaj++;
        //Debug.Log("joy: "+kontroler.Horizontal);
        ruchwbok = kontroler.Horizontal * predkosc;
        if (kontroler.Vertical >= progSkok && delajskok >= 20)
        {
            czyskok = true;
            delajskok = 0;
        }
        else if (kontroler.Vertical <= -progSkok && delajkuc >= 20)
        {
            przykuc = true;
            delajkuc = 0;
        }
        else
        {
            przykuc = false;
            czyskok = false;
        }
        ruch.Move(ruchwbok * Time.fixedDeltaTime, przykuc, czyskok);
        delajskok++;
        delajkuc++;
    }
}
