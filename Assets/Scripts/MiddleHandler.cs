using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class MiddleHandler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite curveUpRight;
    [SerializeField] private Sprite curveUpLeft;
    [SerializeField] private Sprite curveDownRight;
    [SerializeField] private Sprite curveDownLeft;
    
    private Direction direction;
    private List<Direction> directionList;
    private BodypartMovement _bodypartMovement;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bodypartMovement = GetComponent<BodypartMovement>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        directionList = new List<Direction>();
        directionList.Add(Direction.Down);
        directionList.Add(Direction.Down);
    }
    
    private void Update()
    {
        Direction previous = directionList[0];
        Direction current = directionList[1];
        if (_playerMovement.TimerWasReset)
        {
            directionList[0] = directionList[1];
            directionList[1] = GetDirection();
        }
        
        Debug.Log(directionList[0] + " "+ directionList[1]);
        
        
         if ((previous == Direction.Up && current == Direction.Left) 
                 || (previous == Direction.Right && current == Direction.Down))
            _spriteRenderer.sprite = curveDownLeft;
        else if ((previous == Direction.Up && current == Direction.Right) 
                 || (previous == Direction.Left && current == Direction.Down))
           _spriteRenderer.sprite = curveDownRight;
        else if ((previous == Direction.Down && current == Direction.Left) 
                 || (previous == Direction.Right && current == Direction.Up)) 
           _spriteRenderer.sprite = curveUpLeft;
        else if ((previous == Direction.Down && current == Direction.Right) 
                 || (previous == Direction.Left && current == Direction.Up)) 
           _spriteRenderer.sprite = curveUpRight;
         
        else if ((previous == Direction.Up && current == Direction.Up) 
            || (previous == Direction.Down && current == Direction.Down))
            _spriteRenderer.sprite = upSprite;
        else if ((previous == Direction.Right && current == Direction.Right)
                 || (previous == Direction.Left && current == Direction.Left))
            _spriteRenderer.sprite = rightSprite;
    }
    
    private Direction GetDirection()
    {
        if (_bodypartMovement.parent.transform.position.x > transform.position.x)
            direction = Direction.Right;
        else if (_bodypartMovement.parent.transform.position.x < transform.position.x)
            direction = Direction.Left;
        else if (_bodypartMovement.parent.transform.position.y > transform.position.y)
            direction = Direction.Up;
        else if (_bodypartMovement.parent.transform.position.y < transform.position.y)
            direction = Direction.Down;
        return direction;
    }
    
    private enum Direction
    {
        Up, Down, Left, Right
    }
}
