using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private GameObject gameHandler; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            gameHandler.GetComponent<BodyPartHandler>().OnFoodCollect();
            Destroy(other.gameObject);
            StartCoroutine(gameHandler.GetComponent<FoodSpawner>().OnFoodCollect()); 
            gameHandler.GetComponent<ScoreHandler>().IncreaseScore();
        }
        
        else if  (other.gameObject.CompareTag("BodyPart"))
        {
            gameHandler.GetComponent<PlayerFailHandler>().HandleDeath();
        }
    }
    
}
