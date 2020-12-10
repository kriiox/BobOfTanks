using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Image keyZ;
    public Image keyQ;
    public Image keyS;
    public Image keyD;
    public Image leftClic;
    public AudioSource mainMusic;
    
    private void Start()
    {
        // La musique à été faite par un ami donc introuvable sur internet. 
        mainMusic.Play();
    }

    // Permet d'animer les controlles dans le menu. 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            keyZ.GetComponent<Image>().color = new Color32(101,136,47,255);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            keyZ.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.GetComponent<Image>().color = new Color32(101, 136, 47, 255);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            keyQ.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            keyS.GetComponent<Image>().color = new Color32(101, 136, 47, 255);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            keyS.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            keyD.GetComponent<Image>().color = new Color32(101, 136, 47, 255);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            keyD.GetComponent<Image>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            leftClic.GetComponent<Image>().color = new Color32(101, 136, 47, 255);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            leftClic.GetComponent<Image>().color = Color.white;
        }
    }
}
