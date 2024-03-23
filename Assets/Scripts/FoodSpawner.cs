using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private float spawnIntervall = 1f;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        StartCoroutine(OnFoodCollect());
    }

    public IEnumerator OnFoodCollect()
    {
        int posX = Random.Range(-7, 7);
        int posY = Random.Range(-7, 7);
        var position = new Vector3(posX, posY, 0);
        yield return new WaitForSeconds(spawnIntervall);
        Instantiate(food, position, Quaternion.identity);
    }
}
