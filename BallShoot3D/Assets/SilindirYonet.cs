using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // TIKLANIP TIKLANILMADIGINI ANLAMAK ICIN.



// NEDEN bunlari kullandik cunku adam platformu cevirirken 50 kere tiklamicak basili tutcak platform donmeye baslicak birakcak is bitcek gibi dusun. ondan bunlari extend ettik.

                                            //basiyorum mu ?        //biraktik mi ?
public class SilindirYonet : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool ButonPressed;
    public GameObject SilindirObjesi;
    [SerializeField] private float DonusCapi;
    [SerializeField] private string Yon;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButonPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButonPressed)
        {
            if(Yon == "Sol")
            SilindirObjesi.transform.Rotate(0, DonusCapi * Time.deltaTime, 0, Space.Self);
            else
            SilindirObjesi.transform.Rotate(0, -DonusCapi * Time.deltaTime, 0, Space.Self);

        }
       
    }
}
