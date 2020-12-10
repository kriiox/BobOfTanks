using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public int numberKill;
    public static KillCounter instance;
    public Text txtKill;

    // Permet d'actualisé le compteur d'ennemi détruit. 
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance dans KillCounter");
        } else
        {
            instance = this;
        }
    }

    public void setKill()
    {
        numberKill += 1;
        txtKill.text = "" + numberKill;
    }
}
