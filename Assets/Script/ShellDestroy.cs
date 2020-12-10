using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellDestroy : MonoBehaviour
{
    public GameObject explosion;
    public float shellDomage;    
    public int kill;
    public Text txtKill;

    //Fait apparaitre l'effet d'explosion lors d'une collision avec la balle. Puis detruit la balle.
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.GetComponent<healthBar>().SetDamage(shellDomage);
        }

        Destroy(gameObject);
    }

}
