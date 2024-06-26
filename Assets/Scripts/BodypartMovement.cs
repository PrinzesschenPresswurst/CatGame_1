using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodypartMovement : MonoBehaviour
{
    public GameObject parent;
    private Vector3 parentPos;
    private PlayerMovement _playerMovement;
    private BodyPartHandler _bodyPartHandler;
    
    
    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _bodyPartHandler = FindObjectOfType<BodyPartHandler>();
        
        if (_bodyPartHandler.bodyPartList.Count > 2)
            parent = _bodyPartHandler.bodyPartList[^3];
        else parent = _playerMovement.gameObject;
    }

    void Update()
    {
        
        if (!_playerMovement.TimerWasReset)
        {
            parentPos = parent.transform.position;
        }
        
        if (_playerMovement.TimerWasReset)
        {
            transform.position = parentPos;
        }
        
    }

    
    
    
}