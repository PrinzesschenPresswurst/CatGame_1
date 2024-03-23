using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private BodyPartHandler _bodyPartHandler;
    private FoodSpawner _foodSpawner;

    private void Start()
    {
        _bodyPartHandler = FindObjectOfType<BodyPartHandler>();
        _foodSpawner = FindObjectOfType<FoodSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _bodyPartHandler.OnFoodCollect();
        Destroy(other.gameObject);
        StartCoroutine(_foodSpawner.OnFoodCollect());
    }
}
