using UnityEngine;
using DG.Tweening;
using System;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform rotateAround;
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    [SerializeField] float angle = 10f;

    [SerializeField] float duration = 0.2f;
    [SerializeField] float yValue_a;
    private float yValue_b;
    
    void Start()
    {
        DOTween.Init();
        yValue_b = transform.position.y;

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(yValue_a, duration));
        seq.Append(transform.DOMoveY(yValue_b, duration));
        seq.SetLoops(-1, LoopType.Restart);
    }

    void Update()
    {
        transform.RotateAround(rotateAround.position, rotationAxis, angle * Time.deltaTime);
    }
}
