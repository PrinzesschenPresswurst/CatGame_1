using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private BodyPartHandler _bodyPartHandler;
    private FoodSpawner _foodSpawner;
    private PlayerFailHandler _playerFailHandler;
    private ScoreHandler _scoreHandler;

    private void Start()
    {
        _bodyPartHandler = FindObjectOfType<BodyPartHandler>();
        _foodSpawner = FindObjectOfType<FoodSpawner>();
        _playerFailHandler = FindObjectOfType<PlayerFailHandler>();
        _scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            _bodyPartHandler.OnFoodCollect();
            Destroy(other.gameObject);
            StartCoroutine(_foodSpawner.OnFoodCollect()); 
            _scoreHandler.IncreaseScore();
        }
        
        else if  (other.gameObject.CompareTag("BodyPart"))
        {
            _playerFailHandler.HandleDeath();
        }
    }
    
}
