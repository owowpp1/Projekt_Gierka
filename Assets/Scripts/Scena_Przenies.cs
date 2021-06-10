using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scena_Przenies : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Text tekst;
        string nazwasceny;
        tekst = GameObject.Find(this.gameObject.name).GetComponent<Text>();
        nazwasceny = tekst.text;
        Debug.Log("nazwasceny " + nazwasceny);
        SceneManager.LoadScene(nazwasceny);

        Hero_stats.wyburScen.SetActive(false);
    }
}
