using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _timer = 0f;
    [SerializeField] public float moveTimer = 1f;
    public bool TimerWasReset { get; private set; } = false;
    
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    [SerializeField] private GameObject gameHandler; 
    public bool IsAlive { get; set; } = true;
    private BackgroundSize size;
    
    void Start()
    {
        _moveDirection = Vector3.down; // set start direction
        transform.position = Vector3.zero; // set start position
        size = gameHandler.GetComponent<BackgroundSize>();
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        HandleMoveDirection();
        KeepPlayerInBounds();
    }

    private void HandleMovement()
    {
        _timer += Time.deltaTime;
        if (_timer >= moveTimer && IsAlive)
        {
            transform.position += _moveDirection;
            _timer -= moveTimer;
            TimerWasReset = true;
        }
        else TimerWasReset = false;
    }

    private void HandleMoveDirection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && _moveDirection!= Vector3.left)
        {
            _moveDirection = Vector3.right;
            _spriteRenderer.sprite = rightSprite;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow) && _moveDirection != Vector3.right)
        {
            _moveDirection = Vector3.left;
            _spriteRenderer.sprite = leftSprite;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && _moveDirection != Vector3.down)
        {
            _moveDirection = Vector3.up;
            _spriteRenderer.sprite = backSprite;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && _moveDirection != Vector3.up)
        {
            _moveDirection = Vector3.down;
            _spriteRenderer.sprite = frontSprite;
        }
    }

    private void KeepPlayerInBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, size.screenBoundXMin, size.screenBoundXMax);
        pos.y = Mathf.Clamp(pos.y, size.screenBoundYMin, size.screenBoundYMax);
        transform.position = pos;
    }
}