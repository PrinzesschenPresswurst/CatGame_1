using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyPartHandler : MonoBehaviour
{
    [SerializeField] public List<GameObject> bodyPartList; 
    [SerializeField] private GameObject bodyPart;
    public static GameObject bodyPartParent { get; set; }
    void Start()
    {
        bodyPartList = new List<GameObject>();
        bodyPartParent = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void OnFoodCollect()
    {
        GameObject newBodyPart = Instantiate(bodyPart, bodyPartParent.transform.position, bodyPartParent.transform.rotation);
        bodyPartList.Add(newBodyPart);
        newBodyPart.transform.SetParent(this.gameObject.transform);
    }
}
