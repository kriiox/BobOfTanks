using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://www.youtube.com/watch?v=u4ArxWDiPu8

public class AI : MonoBehaviour
{
    public float AISpeed;
    public DetectionArea detectionArea;    
    private RaycastHit Hit;

    void Update()
    {        
        // L'ennemi se déplace en ligne droite et change de direction lorsqu'il entre en contact avec un obstacle. 
        if(detectionArea.isFollow == false)
        {
            transform.Translate(Vector3.forward * AISpeed * Time.deltaTime);

            // Le raycast permet de vérifier la distance entre le joueur et l'environnement. 
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 2))
            {
                transform.Rotate(Vector3.up * Random.Range(50, 200));
            }

        } else
        {            
            // Si le joueur est en mode "Follow" il va prendre la position du joueur comme point de destination. 
            Quaternion targetRotation = Quaternion.LookRotation(detectionArea.GetTargetPosition().position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, AISpeed * Time.deltaTime);
            transform.position += transform.forward * AISpeed * Time.deltaTime;
        }
    }
}
