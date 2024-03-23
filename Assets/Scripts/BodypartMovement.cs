using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartMovement : MonoBehaviour
{
    private GameObject parent;
    private Vector3 parentPos;
    private PlayerMovement _playerMovement;
    private BodyPartHandler _bodyPartHandler;


    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _bodyPartHandler = FindObjectOfType<BodyPartHandler>();
        
        if (_bodyPartHandler.bodyPartList.Count > 1)
            parent = _bodyPartHandler.bodyPartList[^2];
        else parent = _playerMovement.gameObject;
    }

    void Update()
    {
        if (!_playerMovement.resetTimer)
        {
            parentPos = parent.transform.position;
        }
        
        if (_playerMovement.resetTimer)
        {
            transform.position = parentPos;
        }
    }
}