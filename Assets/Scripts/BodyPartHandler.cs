using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyPartHandler : MonoBehaviour
{
    [SerializeField] public List<GameObject> bodyPartList; 
    [SerializeField] private GameObject bodyPart;
    private static GameObject bodyPartParent { get; set; }
    private PlayerMovement _playerMovement;
    private Vector3 parentPosition;
    private Quaternion parentRotation;
    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        bodyPartList = new List<GameObject>();
        bodyPartParent = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void OnFoodCollect()
    {
        parentPosition = bodyPartParent.transform.position;
        parentRotation = bodyPartParent.transform.rotation;
        StartCoroutine(SpawnBodyAfterCatMovedOn());
    }

    private IEnumerator SpawnBodyAfterCatMovedOn()
    {
        yield return new WaitForSeconds(_playerMovement.moveTimer);
        GameObject newBodyPart = Instantiate(bodyPart, parentPosition, parentRotation);
        bodyPartList.Add(newBodyPart);
        newBodyPart.transform.SetParent(this.gameObject.transform);
    }
    
    
}
