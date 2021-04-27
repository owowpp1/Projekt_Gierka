using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wruk_ić : MonoBehaviour
{
    public Transform detektorpodlogi;
    public Transform detektorsciany;
    private float predkosc = 20f;
    private Collider2D ziemia;
    private GameObject ziemiaTM;
    public Animator animacja;

    Rigidbody2D wruk;
    Transform polozenie;
    Vector2 czyZiemia;
    Vector2 czySciana;
    int kjerunek=1;

    // Start is called before the first frame update
    void Start()
    {
        polozenie = this.transform;
        wruk = this.GetComponent<Rigidbody2D>();
        ziemiaTM = GameObject.Find("Ziemia");
        ziemia = ziemiaTM.GetComponent<Collider2D>();
        predkosc = Hero_stats.nme_speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        czyZiemia = detektorpodlogi.position;
        czySciana = detektorsciany.position;
        if (ziemia.OverlapPoint(czyZiemia)&&!ziemia.OverlapPoint(czySciana))
        {
            //Debug.Log("IDE");
            Vector2 ruch = wruk.velocity;
            predkosc = Hero_stats.nme_speed;
            ruch.x = predkosc*kjerunek;
            wruk.velocity = ruch;

        }
        else
        {
            //Debug.Log("Zawracam");
            Flip();
        }
        Vector2 ruch2 = wruk.velocity;
        animacja.SetFloat("predkosc", Mathf.Abs(ruch2.x));
    }
    private void Flip()
    {

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        kjerunek *= -1;
        transform.localScale = theScale;
    }
}
