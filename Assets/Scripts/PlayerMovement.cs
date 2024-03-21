using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 _moveDirection;
   
    void Start()
    {
        _moveDirection = Vector3.right;
    }

  
    void Update()
    {
        float moveFactor = moveSpeed * Time.deltaTime;
        transform.position += _moveDirection * moveFactor;
        
        HandleMoveDirection();
        KeepPlayerInBounds();
    }

    private void KeepPlayerInBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 0.5f, 49.5f);
        pos.y = Mathf.Clamp(pos.y, 0.5f, 49.5f);
        transform.position = pos;
    }

    private void HandleMoveDirection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _moveDirection = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            _moveDirection = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            _moveDirection = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            _moveDirection = Vector3.down; 
    }
}
