using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{

    public CharacterController2D ruch;
    public Joystick kontroler;
    public Animator animacja;
    public Transform detektorkrawedzi;
    public Transform detektorpowietrza;

    public static Vector3 pozycjaStartowa;

    public static float predkosc = 40f;
    public static float ruchwbok;
    public static int delajskok =25;
    public static int delajdrop =11;
    public static int delajlap =0;
    public static float progSkok = .5f;
    public static bool czyskok = false;
    public static bool przykuc = false;
    public static bool grab = false;
    public static bool wchodzi = false;
    public static bool znamStrone = false;
    public static int facing = 1;  //1-prawo, -1-lewo

    private GameObject ziemiaTM;
    private Collider2D ziemia;
    private Vector2 czyKrawedz;
    private Vector2 czyPowietrze;
    private Rigidbody2D postac;
    private Vector3 wspinaczka = new Vector3(0.5f, 1.7f, 0);
    private Vector3 progres;

    RigidbodyConstraints2D oryginalneConstrainty;


    void Start()
    {
        pozycjaStartowa = transform.position;
        ziemiaTM = GameObject.Find("Ziemia");
        ziemia = ziemiaTM.GetComponent<Collider2D>();
        postac = this.GetComponent<Rigidbody2D>();
        oryginalneConstrainty = postac.constraints;

    }
    public void londowanko()
    {
        animacja.SetBool("czyskok", false);
        //Debug.Log("londowane");
    }
    public void kucanko(bool kuc)
    {
        animacja.SetBool("przykuc", kuc);
    }
    void FixedUpdate()
    {
        ruchwbok = kontroler.Horizontal * predkosc;
        czyKrawedz = detektorkrawedzi.position;
        czyPowietrze = detektorpowietrza.position;
        if (kontroler.Vertical >= progSkok && delajskok >= 20 && !(animacja.GetBool("przykuc")) && !grab)
        {
            czyskok = true;
            animacja.SetBool("czyskok", true);
            delajskok = 0;
        }
        else if (kontroler.Vertical <= -progSkok && !czyskok && delajskok >= 20 && !grab)
        {
            przykuc = true;
        }
        else
        {
            czyskok = false;
            przykuc = false;
        }
        if (!grab)
        {
            animacja.SetFloat("predkosc", Mathf.Abs(ruchwbok));
            ruch.Move(ruchwbok * Time.fixedDeltaTime, przykuc, czyskok);
        }
        if (ziemia.OverlapPoint(czyKrawedz) && !ziemia.OverlapPoint(czyPowietrze) && delajdrop>30 && !Hero_stats.ded)
        {
            grab = true;
            Hero_stats.vulnerable = false;
            postac.constraints |= RigidbodyConstraints2D.FreezePosition;
            delajlap++;
            animacja.SetBool("czyskok", false);
            animacja.SetBool("wisi", true);
            if (!znamStrone)
            {
                znamStrone = true;
                if (Hero_stats.Facing < 0) facing = -1;
                else facing = 1;
            }
            if (kontroler.Vertical >= progSkok && delajlap>4)
            {
                delajdrop = 0;
                delajlap = 0;
                ruchwbok = 0;
                Debug.Log("wchodzi");
                animacja.SetBool("wisi", false);
                animacja.SetTrigger("wchodzi");
                Invoke("wylonczgrab", .8f);
                wchodzi = true;
                if (facing > 0) wspinaczka.x = Mathf.Abs(wspinaczka.x);
                else wspinaczka.x = -Mathf.Abs(wspinaczka.x);

                progres = transform.position + wspinaczka;
                Hero_stats.vulnerable = true;

            }
            else if(kontroler.Vertical <= -progSkok && delajlap > 4)
            {
                delajdrop = 0;
                delajlap = 0;
                ruchwbok = 0;
                postac.constraints = oryginalneConstrainty;
                animacja.SetBool("wisi", false);
                grab = false;
                Hero_stats.vulnerable = true;
                znamStrone = false;
            }
        }
        if (wchodzi)
        {
            transform.position += (progres-transform.position) * 4 * Time.deltaTime;
        }
            
        delajskok++;
        delajdrop++;
    }
    void wylonczgrab()
    {
        grab = false;
        wchodzi = false;
        znamStrone = false;
        Hero_stats.vulnerable = true;
        postac.constraints = oryginalneConstrainty;
    }
}
