using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public UnityEngine.UI.Button btn,sonn;

    public AudioClip altin, dusme;

    public oyunKontrol ok;
    private float hiz = 7;
    public bool isGrounded;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ok.oyunaktif)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            x *= Time.deltaTime * hiz;
            y *= Time.deltaTime * hiz;

            transform.Translate(x, 0f, y);
            if (isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                    rb.AddForce(new Vector3(0, hiz, 0), ForceMode.Impulse);
            }

        }
    }

    void OnCollisionEnter(Collision c)
    {

        if (c.gameObject.tag.Equals("altin"))
        {
            ok.altinart();
            Destroy(c.gameObject);
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);

        }
        else if (c.gameObject.tag.Equals("düsman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 1f);
            ok.oyunaktif = false;
            btn.gameObject.SetActive(true);
            sonn.gameObject.SetActive(true);

            //Application.Quit();

        }

        if (c.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }

}
