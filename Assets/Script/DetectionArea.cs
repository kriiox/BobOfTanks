using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    private Transform targetPosition;
    public bool isFollow = false;

    // Permet de changer d'activer ou non le mode "Follow" pour suivre le joueur si il entre dans la zone de detection. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollow = true;
            targetPosition = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollow = false;
        }
    }

    public Transform GetTargetPosition()
    {
        return targetPosition;
    }
}
