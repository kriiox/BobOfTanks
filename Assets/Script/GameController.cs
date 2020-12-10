using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public List<GameObject> spawnPoints;
    
    public GameObject enemyPrefab;
    public GameObject gameOverUI;

    public float timer;
    public float targetTime = 0f;
    public float timeToSpawn = 10f;
    
    public bool isStart = true;
    public bool gameEnded = false;

    public Text txtStart;
    
    public SFXPlaying sfxPlaying;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Il y a plus d'une instance dans GameController");
        } else
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("StartCountdown");        
    }

    // Décompte de début de partie.
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(0.8f);
        txtStart.text = "3";
        sfxPlaying.PlayCountDown_a();
        yield return new WaitForSeconds(0.8f);
        txtStart.text = "2";
        sfxPlaying.PlayCountDown_a();
        yield return new WaitForSeconds(0.8f);
        txtStart.text = "1";
        sfxPlaying.PlayCountDown_a();
        yield return new WaitForSeconds(0.8f);
        txtStart.text = "GO";
        sfxPlaying.PlayCountDown_b();
        yield return new WaitForSeconds(0.8f);
        Destroy(txtStart);
        isStart = false;
        SpawnEnemy();
    }

    // Tout les X temps un ennemi est instancier sur l'un des 4 points de spawn possible.
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= targetTime + timeToSpawn)
        {
            targetTime = timer;
            SpawnEnemy();
        }

        if(gameEnded == true)
        {
            gameOverUI.SetActive(true);
        }
    }

    // Fonction pour faire spawn un ennemi aléatoirement sur l'un des points de spawn de la carte. 
    private void SpawnEnemy()
    {
        int randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
        Debug.Log(randomSpawn);
        Instantiate(enemyPrefab, spawnPoints[randomSpawn].transform.position, Quaternion.Euler(spawnPoints[randomSpawn].transform.rotation.eulerAngles));
    }


}
