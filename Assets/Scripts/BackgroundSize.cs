using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundSize : MonoBehaviour
{
    [SerializeField] private GameObject background;
    private Vector3 _scale;
    private float _offset = 0.5f;
    public float screenBoundXMin { get; set; }
    public float screenBoundXMax { get; set; }
    public float screenBoundYMin { get; set; }
    public float screenBoundYMax { get; set; }
    
    void Start()
    {
        _scale = background.gameObject.transform.localScale;
        Debug.Log(_scale.x);
        screenBoundXMin = (- _scale.x /2) + _offset;
        screenBoundXMax = (_scale.x /2) - _offset;
        screenBoundYMin = (- _scale.y /2) + _offset; 
        screenBoundYMax = (_scale.y /2) - _offset;
    }
}
