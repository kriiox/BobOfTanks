using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{    
    public float shellSpeed;
    public bool isFire = true;

    public GameObject shellPrefab;
    public GameObject reloadBar;
    public Transform shellSpawn;    
    public SFXPlaying sfxPlaying;

    // Permet de gerer les tires du joueur.
    private void Update()
    {
        // Instancie une balle lorsque le joueur utilise le clique gauche. 
        if (Input.GetMouseButtonDown(0) && isFire == true && GameController.instance.gameEnded == false)
        {
            sfxPlaying.PlayTurrelShoot();
            InstantiateShell(shellSpawn);
            isFire = false;
            StartCoroutine("ReloadShell");
        }
    }

    // Active l'animation du rechargement de la balle.
    IEnumerator ReloadShell()
    {
        reloadBar.SetActive(true);
        reloadBar.transform.parent.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        reloadBar.SetActive(false);
        reloadBar.transform.parent.gameObject.SetActive(false);
        isFire = true;
    }

    private void InstantiateShell(Transform positionShell)
    {
        GameObject shellBody = Instantiate(shellPrefab, positionShell.position, Quaternion.Euler(positionShell.rotation.eulerAngles));
        shellBody.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * shellSpeed;
    }
}
