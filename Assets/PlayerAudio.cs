using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;
    public AudioSource audioS;
    public AudioClip SplooshSound;
    public AudioMixerSnapshot mainMusic;
    public AudioMixerSnapshot battleMusic;
    public AudioMixerSnapshot AmbIdle;
    public AudioMixerSnapshot AmbIn;

    public LayerMask enemyMask;

    bool enemyNear;


    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 5f, transform.forward, 0f, enemyMask);
        if (hits.Length > 0)
        {
            if (!enemyNear)
            {
                battleMusic.TransitionTo(0.5f);
                enemyNear = true;
            }

       }

        else
        {
            if (enemyNear)
            {
                mainMusic.TransitionTo(0.5f);
                enemyNear = false;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }

        if(other.CompareTag("EnemyTrigger"))
        {
            battleMusic.TransitionTo(0.5f);
        }

        if (other.CompareTag("ambiance"))
        {
            AmbIn.TransitionTo(.5f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }

        if (other.CompareTag("EnemyTrigger"))
        {
            mainMusic.TransitionTo(0.5f);
        }

        if (other.CompareTag("ambiance"))
        {
            AmbIdle.TransitionTo(.5f);
        }
    }



}
