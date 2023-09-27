using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kova")){

            // gameObject.transform.localPosition = Vector3.zero;
            // gameObject.transform.localPosition = Quaternion.Euler(Vector3.zero);

            gameObject.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
           

        }else if (other.CompareTag("AltObje"))
        {
            // gameObject.transform.localPosition = Vector3.zero;
            // gameObject.transform.localPosition = Quaternion.Euler(Vector3.zero);

            gameObject.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
