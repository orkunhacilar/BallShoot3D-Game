using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameManager _GameManager;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kova")){

            Renderer renk = GetComponent<Renderer>(); // materialden renk almak icin once renderera erisiyorum

            _GameManager.ParcEfekt(gameObject.transform.position, renk.material.color); // yazdigimiz metoda iligi parametreleri gonderiyoruz.

            // gameObject.transform.localPosition = Vector3.zero;
            // gameObject.transform.localPosition = Quaternion.Euler(Vector3.zero);

            gameObject.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            _GameManager.TopGirdi();
           

        }else if (other.CompareTag("AltObje"))
        {
            Renderer renk = GetComponent<Renderer>(); // materialden renk almak icin once renderera erisiyorum

            _GameManager.ParcEfekt(gameObject.transform.position, renk.material.color); // yazdigimiz metoda iligi parametreleri gonderiyoruz.

            // gameObject.transform.localPosition = Vector3.zero;
            // gameObject.transform.localPosition = Quaternion.Euler(Vector3.zero);

            gameObject.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            _GameManager.TopGirmedi();
        }
    }
}
