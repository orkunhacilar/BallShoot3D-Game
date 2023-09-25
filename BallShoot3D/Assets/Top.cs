using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kova")){

            gameObject.transform.position = Vector3.zero;
            gameObject.SetActive(false);

        }else if (other.CompareTag("AltObje"))
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
