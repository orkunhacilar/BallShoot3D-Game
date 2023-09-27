using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("UI AYARLARI")]
    public GameObject[] Paneller;
    public TextMeshProUGUI YildizSayisi;
    public TextMeshProUGUI Kazandin_LevelSayisi;
    public TextMeshProUGUI Kaybettin_LevelSayisi;


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
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1); //lv gecersen Level stringine bir sonraki lvnin sceneindexini ata
            PlayerPrefs.SetInt("Yildiz", PlayerPrefs.GetInt("Yildiz") + 15);
            YildizSayisi.text = PlayerPrefs.GetInt("Yildiz").ToString();
            Kazandin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[1].SetActive(true);
        }

        if (MevutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }

        if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }
    }

    public void TopGirmedi()
    {
       

        if(MevutTopSayisi == 0)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
        }
        if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
        {
            Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[2].SetActive(true);
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

    public void OyunuDurdur()
    {
        Paneller[0].SetActive(true);
        Time.timeScale = 0; // oyununu durdurmak icin zamani durduruyoruz.
    }

    public void PanellerIcinButonIslemi(string islem)
    {
        switch (islem)
        {
            case "Devamet":
                Time.timeScale = 1;
                Paneller[0].SetActive(false);
                break;
            case "Cikis":
                Application.Quit();
                break;
            case "Ayarlar":
                break;
            case "Tekrar":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // aktif olan sahneyi bir daha yukle
                break;
            case "Birsonraki":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // aktif olan sahneyi bir daha yukle
                break;

        }
    }


}
