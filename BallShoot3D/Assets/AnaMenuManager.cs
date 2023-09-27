using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        } else
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("Yildiz", 0);
            SceneManager.LoadScene(1);
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
