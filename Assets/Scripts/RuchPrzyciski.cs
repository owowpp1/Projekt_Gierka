using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RuchPrzyciski : MonoBehaviour
{
    public static bool czywlewo;
    public static bool czywprawo;
    public static bool czyskok;
    public static int delaj = 0;

    void OnMouseDrag()
    {
        Debug.Log(gameObject.name + delaj);
        switch (gameObject.name)
        {
            case "lewo":
                czywlewo = true;
                break;
            case "prawo":
                czywprawo = true;
                break;
            case "skok":
                if (delaj >= 20)
                {
                    delaj = 0;
                    czyskok = true;
                }
                break;
            default:
                Debug.Log("Nic");
                break;
        }
    }


}
