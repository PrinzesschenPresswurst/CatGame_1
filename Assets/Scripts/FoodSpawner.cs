using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private Sprite foodSprite;
    [SerializeField] private float spawnIntervall = 1f;
    

    private void Start()
    {
        StartCoroutine(OnFoodCollect());
    }

    public IEnumerator OnFoodCollect()
    {
        BackgroundSize size = GetComponent<BackgroundSize>();
        int posX = Random.Range(Convert.ToInt32(size.screenBoundXMin) +1,Convert.ToInt32(size.screenBoundXMax));
        int posY = Random.Range(Convert.ToInt32(size.screenBoundYMin)+1 ,Convert.ToInt32(size.screenBoundYMax));
        var position = new Vector3(posX, posY, 0);
        yield return new WaitForSeconds(spawnIntervall);
        Instantiate(food, position, Quaternion.identity);
    }
}
