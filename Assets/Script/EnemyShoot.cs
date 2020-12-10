using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject shellPrefab;    
    public Transform shellSpawn;
    public DetectionArea detectionArea;
    private bool isFire = true;
    public float shellSpeed;

    private void Update()
    {
        // Permet d'instancier une balle si l'ennemi n'est pas en mode "reload", si il suit un joueur et si la partie n'est pas terminé. 
        if (isFire == true && detectionArea.isFollow == true && GameController.instance.gameEnded == false)
        {
            InstantiateShell(shellSpawn);
            isFire = false;
            StartCoroutine("ReloadShell");
        }
    }

    IEnumerator ReloadShell()
    {
        yield return new WaitForSeconds(2f);
        isFire = true;
    }

    private void InstantiateShell(Transform positionShell)
    {
        // Quaterion.Euler permet d'instancier la rotation de la balle sur 4 composantes (X-Y-Z-W), permet d'éviter certains effets indésirables.
        GameObject shellBody = Instantiate(shellPrefab, positionShell.position, Quaternion.Euler(positionShell.rotation.eulerAngles));
        shellBody.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * shellSpeed;
    }
}
