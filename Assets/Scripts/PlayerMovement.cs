using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _timer = 0f;
    [SerializeField] public float moveTimer = 1f;
    public bool resetTimer { get; private set; } = false;
    
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;

    [SerializeField] private float screenBoundX = 9.5f;
    [SerializeField] private float screenBoundY = -9.5f;
    
    void Start()
    {
        _moveDirection = Vector3.right; // set start direction
        transform.position = new Vector3(-9.5f, -9.5f, 0f); // set start position
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
        if (_timer >= moveTimer)
        {
            transform.position += _moveDirection;
            _timer -= moveTimer;
            resetTimer = true;
        }
        else resetTimer = false;
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
        pos.x = Mathf.Clamp(pos.x, screenBoundX, screenBoundY);
        pos.y = Mathf.Clamp(pos.y, screenBoundX, screenBoundY);
        transform.position = pos;
    }
}