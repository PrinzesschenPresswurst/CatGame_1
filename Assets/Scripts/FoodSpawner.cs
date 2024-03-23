using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private float spawnIntervall = 1f;

    private void Start()
    {
        StartCoroutine(OnFoodCollect());
    }

    public IEnumerator OnFoodCollect()
    {
        int posX = Random.Range(-9, 9);
        int posY = Random.Range(-9, 9);
        var position = new Vector3(posX, posY, 0);
        yield return new WaitForSeconds(spawnIntervall);
        Instantiate(food, position, Quaternion.identity);
    }
}
