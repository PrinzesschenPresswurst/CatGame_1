using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ButtSpriteHandler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        GameObject parent = GetComponent<BodypartMovement>().parent;
        if (transform.position.y - parent.transform.position.y < 0)
            _spriteRenderer.sprite = upSprite;
        else if (transform.position.y - parent.transform.position.y > 0)
            _spriteRenderer.sprite = downSprite;
        else if (transform.position.x - parent.transform.position.x < 0)
            _spriteRenderer.sprite = rightSprite;
        else if (transform.position.x - parent.transform.position.x > 0)
            _spriteRenderer.sprite = leftSprite;

    }
}
