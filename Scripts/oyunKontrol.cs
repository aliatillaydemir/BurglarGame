using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunKontrol : MonoBehaviour
{
    public bool oyunaktif = true;
    public int altinsayisi = 0;
    public UnityEngine.UI.Text altins;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Play();
        // GetComponent<AudioSource>().Stop(); ba�tan ba�lar tekrar a�lat�nca
        //GetComponent<AudioSource>().Pause(); devam eder kald��� yerden
        //ikisi de durdurmak i�in kullan�loyr
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void altinart()
    {
        altinsayisi += 1;
        altins.text = "" + altinsayisi;
    }

}
