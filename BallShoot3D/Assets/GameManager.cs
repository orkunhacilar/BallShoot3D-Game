using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] Toplar;
    public GameObject FirePoint;
    public float TopGucu;
    int AktifTopIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            Toplar[AktifTopIndex].transform.SetPositionAndRotation(FirePoint.transform.position, FirePoint.transform.rotation);
            Toplar[AktifTopIndex].SetActive(true);

            //bir obje yarat bu top olsun ve firepointin pozisyon ve rotasyonunda meydana gelsin.
            //  GameObject tp = Instantiate(Top, FirePoint.transform.position, FirePoint.transform.rotation);

            //acilar     // itis gucu
            Toplar[AktifTopIndex].GetComponent<Rigidbody>().AddForce(Toplar[AktifTopIndex].transform.TransformDirection(90, 90, 0) * TopGucu, ForceMode.Force);

            AktifTopIndex++;

            if (Toplar.Length - 1 == AktifTopIndex)
                AktifTopIndex = 0;
            else
                AktifTopIndex++;
        }

    }
}
