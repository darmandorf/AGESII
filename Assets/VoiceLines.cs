using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour 
{
    [SerializeField]
    private AudioClip audioClip;

    private SphereCollider spCollider;
    private AudioSource audioSource;

    private void Awake()
    {
        spCollider = gameObject.GetComponent<SphereCollider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            spCollider.enabled = false;
        }
    }
}
