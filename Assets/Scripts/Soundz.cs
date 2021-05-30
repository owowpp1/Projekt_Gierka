using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundz : MonoBehaviour
{

    public static AudioClip dzgon, oof, ciach, zabij_dzwiek;
    static AudioSource AudioScr;
    
    // Start is called before the first frame update
   
    void Start()
    {
        dzgon =Resources.Load<AudioClip>("bigfall");
        oof = Resources.Load<AudioClip>("oof");
        ciach = Resources.Load<AudioClip>("mjecz");
        zabij_dzwiek = Resources.Load<AudioClip>("bigfall");

        AudioScr = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GrajDzwiek (string clip)
    {
        switch (clip)
        {
            case "dzgon":
                AudioScr.PlayOneShot(dzgon);
                break;
            case "oof":
                AudioScr.PlayOneShot(oof);
                break;

            case "ciach":
                AudioScr.PlayOneShot(ciach);
                break;
            case "zabij_dzwiek":
                AudioScr.PlayOneShot(zabij_dzwiek);
                break;
        }
    }
}
