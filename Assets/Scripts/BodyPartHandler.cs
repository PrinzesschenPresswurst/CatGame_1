using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyPartHandler : MonoBehaviour
{
    [SerializeField] public List<GameObject> bodyPartList; 
    [SerializeField] private GameObject bodyPart;
    [SerializeField] GameObject catButt;
    private static GameObject bodyPartSpawn { get; set; }
    private PlayerMovement _playerMovement;
    private Vector3 parentPosition;
    private Quaternion parentRotation;
    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        bodyPartList = new List<GameObject>();
        //bodyPartParent = GameObject.FindGameObjectWithTag("Player");
        if (bodyPartList.Count<1)
            bodyPartSpawn = GameObject.FindGameObjectWithTag("Player");
        else bodyPartSpawn = bodyPartList[^1];
        
        GameObject butt =Instantiate(catButt, parentPosition, parentRotation);
        bodyPartList.Add(butt);
    }
    
    public void OnFoodCollect()
    {
        parentPosition = bodyPartSpawn.transform.position;
        parentRotation = bodyPartSpawn.transform.rotation;
        StartCoroutine(SpawnBodyAfterCatMovedOn());
    }

    private IEnumerator SpawnBodyAfterCatMovedOn()
    {
        yield return new WaitForSeconds(_playerMovement.moveTimer);
        
        GameObject newBodyPart = Instantiate(bodyPart, parentPosition, parentRotation);
        bodyPartList.Insert(bodyPartList.Count -1, newBodyPart);
        
        newBodyPart.transform.SetParent(this.gameObject.transform);
        
        bodyPartList[^1].GetComponent<BodypartMovement>().parent = bodyPartList[^2];
    }
    
    
}
