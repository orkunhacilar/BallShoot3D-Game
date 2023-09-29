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
    public Animator _TopAtar;
    public ParticleSystem TopAtmaEfekt;
    public ParticleSystem[] TopEfektleri;
    int AktifTopEfektIndex;
    public AudioSource[] TopSesleri;
    int AktifTopSesIndex;

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

    [Header("DIGER AYARLAR")]
    public Renderer KovaSeffaf;
    float KovaninBaslangicDegeri;
    float KovaStepDegeri;
    [SerializeField] private AudioSource[] DigerSesler;
   


    // Start is called before the first frame update
    void Start()
    {
        AktifTopEfektIndex = 0;
        AktifTopSesIndex = 0;

        KovaninBaslangicDegeri = .5f;

        KovaStepDegeri = .25f / HedefTopSayisi;

        LevelSlider.maxValue = HedefTopSayisi;
        KalanTopSayisi_Text.text = MevutTopSayisi.ToString();

      
    }

    


    public void TopGirdi()
    {
        GirenTopSayisi++;
        LevelSlider.value = GirenTopSayisi;

        KovaninBaslangicDegeri -= KovaStepDegeri;

        KovaSeffaf.material.SetTextureScale("_MainTex", new Vector2(1f, KovaninBaslangicDegeri));

        TopSesleri[AktifTopSesIndex].Play();
        AktifTopSesIndex++;

        if (AktifTopSesIndex == TopSesleri.Length - 1) //aktiftopefektindexim Topefektlerimin sayisina gelince sifirliyorum. tekrar baslatabilmek adina efektleri
            AktifTopSesIndex = 0;

        if (GirenTopSayisi == HedefTopSayisi)
        {
            DigerSesler[1].Play();
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1); //lv gecersen Level stringine bir sonraki lvnin sceneindexini ata
            PlayerPrefs.SetInt("Yildiz", PlayerPrefs.GetInt("Yildiz") + 15);
            YildizSayisi.text = PlayerPrefs.GetInt("Yildiz").ToString();
            Kazandin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
            Paneller[1].SetActive(true);
        }


        int sayi = 0;
        foreach(var item in Toplar)
        {
            if (item.activeInHierarchy)    // siradaki top aktifmi degilmi ona bakiyoruz.
                sayi++;
        }

        if(sayi == 0)
        {
            if (MevutTopSayisi == 0 && GirenTopSayisi != HedefTopSayisi)
            {
                DigerSesler[0].Play();
                Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
                Paneller[2].SetActive(true);
            }

            if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
            {
                DigerSesler[0].Play();
                Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
                Paneller[2].SetActive(true);
            }
        }

        
    }

    public void TopGirmedi()
    {

        int sayi = 0;
        foreach (var item in Toplar)
        {
            if (item.activeInHierarchy)    // siradaki top aktifmi degilmi ona bakiyoruz.
                sayi++;
        }

        if (sayi == 0)
        {
            if (MevutTopSayisi == 0)
            {
                DigerSesler[0].Play();
                Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
                Paneller[2].SetActive(true);
            }
            if ((MevutTopSayisi + GirenTopSayisi) < HedefTopSayisi)
            {
                DigerSesler[0].Play();
                Kaybettin_LevelSayisi.text = "LEVEL : " + SceneManager.GetActiveScene().name;
                Paneller[2].SetActive(true);
            }
        }


            
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            MevutTopSayisi--;
            KalanTopSayisi_Text.text = MevutTopSayisi.ToString();
            _TopAtar.Play("TopAtar"); //topatarin icindeki su animasyon klibini oynat
            TopAtmaEfekt.Play(); // top atma efecktinide play yap
            DigerSesler[2].Play();
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


    public void ParcEfekt(Vector3 Pozisyon, Color Renk)
    {
        TopEfektleri[AktifTopEfektIndex].transform.position = Pozisyon; // topun pozisyonunu efektin pozisyonuna atiyorum.

        var main = TopEfektleri[AktifTopEfektIndex].main; //particle efecktin alt basliklarina erisebilmek icin boyle yaptik.
        main.startColor = Renk; //particle effectin start coloruna parametre olarak gelen topun rengini veriyoruz !

        TopEfektleri[AktifTopEfektIndex].gameObject.SetActive(true); // ve o efeckti aciga cikariyorum
        AktifTopEfektIndex++;

        if (AktifTopEfektIndex == TopEfektleri.Length - 1) //aktiftopefektindexim Topefektlerimin sayisina gelince sifirliyorum. tekrar baslatabilmek adina efektleri
            AktifTopEfektIndex = 0;
    }


}
