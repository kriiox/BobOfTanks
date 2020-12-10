using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource TurrelShoot;
    public AudioSource CountDown_a;
    public AudioSource CountDown_b;

    // Gestion des sons du jeu. 

    public void PlayTurrelShoot()
    {
        TurrelShoot.Play();
    }

    public void PlayCountDown_a()
    {
        CountDown_a.Play();
    }

    public void PlayCountDown_b()
    {
        CountDown_b.Play();
    }
}
