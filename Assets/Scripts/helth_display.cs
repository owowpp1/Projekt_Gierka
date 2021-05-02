using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helth_display : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + Hero_stats.currHealth.ToString() ;
    }
}
