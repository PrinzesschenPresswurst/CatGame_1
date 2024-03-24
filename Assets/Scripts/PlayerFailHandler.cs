using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFailHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [SerializeField] private ParticleSystem deathParticle;
    [SerializeField] private Canvas deathCanvas;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void HandleDeath()
    {
        Debug.Log("you died");
        _playerMovement.IsAlive = false;
        deathParticle.Play();
        deathCanvas.gameObject.SetActive(true);
    }
}