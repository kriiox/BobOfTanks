using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustedTankDestroy : MonoBehaviour
{
    // Detruit les debris de tank ennemi au bout de 10sec. 
    void Start()
    {
        Destroy(gameObject, 10f);
    }
}
