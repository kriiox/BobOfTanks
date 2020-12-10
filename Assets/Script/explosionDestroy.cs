using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionDestroy : MonoBehaviour
{
    // Detruit l'effet d'explosion 2 sec après son apparition. 
    void Start()
    {
        Destroy(gameObject, 2f);
    }
}
