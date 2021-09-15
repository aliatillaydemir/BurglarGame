using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    public oyunKontrol oky;

    float hassasiyet=3f;
    float yumusaklik=1.5f;

    Vector2 gecisPos;
    Vector2 camPos;

    GameObject oyuncu;

    void Start()
    {  
        oyuncu = transform.parent.gameObject;
        camPos.y = 12f; //ba�lang�cta oyuncunuun bakt�g� yer
    }

    void Update()
    {
        if (oky.oyunaktif)
        {
            Vector2 farePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            //farenin pozisyonunu almak i�in 2 boyutlu bilgileri(inputlar�) al�yoruz

            farePos = Vector2.Scale(farePos, new Vector2(hassasiyet * yumusaklik, hassasiyet * yumusaklik));
            //mouse hareketleri iyile�tiriliyor.
            gecisPos.x = Mathf.Lerp(gecisPos.x, farePos.x, 1f / yumusaklik);
            gecisPos.y = Mathf.Lerp(gecisPos.y, farePos.y, 1f / yumusaklik);

            camPos += gecisPos;
            transform.localRotation = Quaternion.AngleAxis(-camPos.y, Vector3.right);
            oyuncu.transform.localRotation = Quaternion.AngleAxis(camPos.x, oyuncu.transform.up);

        }
    }
}
