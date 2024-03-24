using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MiddleHandler : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BodyPartHandler _bodyPartHandler;

    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite curveUpRight;
    [SerializeField] private Sprite curveUpLeft;
    [SerializeField] private Sprite curveDownRight;
    [SerializeField] private Sprite curveDownLeft;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bodyPartHandler = FindObjectOfType<BodyPartHandler>();
    }

    void Update()
    {
        GameObject parent = GetComponent<BodypartMovement>().parent;
        int i = _bodyPartHandler.bodyPartList.IndexOf(parent);
        GameObject after = _bodyPartHandler.bodyPartList[i +2];

        if (transform.position.y - parent.transform.position.y != 0 && 
            transform.position.x - after.transform.position.x < 1)
            _spriteRenderer.sprite = curveDownLeft;
        else if (transform.position.y - parent.transform.position.y != 0 && 
                 transform.position.x - after.transform.position.x < 1)
                _spriteRenderer.sprite = curveUpLeft;
        else if (transform.position.y - parent.transform.position.y != 0) 
            _spriteRenderer.sprite = upSprite;
        else if (transform.position.x - parent.transform.position.x != 0 && 
                 transform.position.y - after.transform.position.y < 1)
                _spriteRenderer.sprite = curveUpRight;
        else if (transform.position.x - parent.transform.position.x != 0 && 
                 transform.position.y - after.transform.position.y < 1)
                _spriteRenderer.sprite = curveDownRight;
        else  if (transform.position.x - parent.transform.position.x != 0)
            _spriteRenderer.sprite = rightSprite;
    }
}
