using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scena_Przenies : MonoBehaviour, IPointerDownHandler
{
    public GameObject lista;
    public void OnPointerDown(PointerEventData eventData)
    {
        Text tekst;
        string nazwasceny;
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        tekst = GameObject.Find(this.gameObject.name).GetComponent<Text>();
        nazwasceny = tekst.text;
        //Debug.Log(nazwasceny);
        SceneManager.LoadScene(nazwasceny);

        lista.SetActive(false);

    }
}
