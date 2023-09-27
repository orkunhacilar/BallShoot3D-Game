using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("--TOP AYARLARI")]
    public GameObject[] Toplar;
    public GameObject FirePoint;
    [SerializeField] private float TopGucu;
    int AktifTopIndex;
    [Header("LEVEL AYARLARI")]
    [SerializeField] private int HedefTopSayisi;
    [SerializeField] private int MevutTopSayisi;
    public int GirenTopSayisi;
    public Slider LevelSlider;
    public TextMeshProUGUI KalanTopSayisi_Text;


    // Start is called before the first frame update
    void Start()
    {
        LevelSlider.maxValue = HedefTopSayisi;
        KalanTopSayisi_Text.text = MevutTopSayisi.ToString();
    }

    public void TopGirdi()
    {
        GirenTopSayisi++;
        LevelSlider.value = GirenTopSayisi;
       


        if (GirenTopSayisi == HedefTopSayisi)
        {
            //Top atma islevini kitleyecegiz.
            Debug.Log("Kazandin");
        }

        if (MevutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
            Debug.Log("Kaybettin");
        }

        if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
        }
    }

    public void TopGirmedi()
    {
       

        if(MevutTopSayisi == 0)
        {
            Debug.Log("Kaybettin");
        }
        if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Debug.Log("Kaybettin");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            MevutTopSayisi--;
            KalanTopSayisi_Text.text = MevutTopSayisi.ToString();
            Toplar[AktifTopIndex].transform.SetPositionAndRotation(FirePoint.transform.position, FirePoint.transform.rotation);
            Toplar[AktifTopIndex].SetActive(true);

            //bir obje yarat bu top olsun ve firepointin pozisyon ve rotasyonunda meydana gelsin.
            //  GameObject tp = Instantiate(Top, FirePoint.transform.position, FirePoint.transform.rotation);

            //acilar     // itis gucu
            Toplar[AktifTopIndex].GetComponent<Rigidbody>().AddForce(Toplar[AktifTopIndex].transform.TransformDirection(90, 90, 0) * TopGucu, ForceMode.Force);

            //AktifTopIndex++;

            if (Toplar.Length - 1 == AktifTopIndex)
                AktifTopIndex = 0;
            else
                AktifTopIndex++;
        }

    }


}
