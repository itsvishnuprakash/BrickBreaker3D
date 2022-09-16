using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject block;
    [SerializeField] private AudioSource soundEffect;
    private void Start() 
    {
        particles.Pause();
    }
    private void OnCollisionEnter(Collision other) 
    {
        soundEffect.Play();
        particles.Play();
        Destroy(GetComponent<BoxCollider>());
        block.SetActive(false);
        
    }
}
