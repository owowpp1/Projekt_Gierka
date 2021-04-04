using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{

    public CharacterController2D ruch;
    public Joystick kontroler;
    public Animator animacja;

    public static Vector3 pozycjaStartowa;

    public static float predkosc = 40f;
    public static float ruchwbok;
    public static int delajskok =20;
    public static float progSkok = .5f;
    public static bool czyskok = false;
    public static bool przykuc = false;


    void Start()
    {
        //Debug.Log("start");
        pozycjaStartowa = transform.position;
        //Debug.Log(pozycjaStartowa);
    }
    public void londowanko()
    {
        animacja.SetBool("czyskok", false);
        Debug.Log("londowane");
    }
    public void kucanko(bool kuc)
    {
        animacja.SetBool("przykuc", kuc);
    }
    void FixedUpdate()
    {
        ruchwbok = kontroler.Horizontal * predkosc;
        if (kontroler.Vertical >= progSkok && delajskok >= 20)
        {
            czyskok = true;
            animacja.SetBool("czyskok", true);
            delajskok = 0;
        }
        else if (kontroler.Vertical <= -progSkok && !czyskok && delajskok >= 20)
        {
            przykuc = true;
        }
        else
        {
            czyskok = false;
            przykuc = false;
        }
        animacja.SetFloat("predkosc", Mathf.Abs(ruchwbok));
        ruch.Move(ruchwbok * Time.fixedDeltaTime, przykuc, czyskok);
        delajskok++;
    }
}
