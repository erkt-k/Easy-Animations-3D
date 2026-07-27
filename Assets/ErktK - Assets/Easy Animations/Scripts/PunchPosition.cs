using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PunchPosition : MonoBehaviour
{
    [Header("Animation Properties")]
    [Tooltip("The direction and strength of animation in each axis.")]
    [SerializeField] Vector3 m_punch = new Vector3(0f, 0.2f, 0f);

    [Tooltip("How long the animation is")]
    [SerializeField] float m_duration = 0.8f;

    [Tooltip("How much will the punch vibrate")]
    [SerializeField] int m_vibrato = 10;

    [Tooltip("[0,1] : How much the vector will go beyond the initial positin when bouncing backwards.")]
    [Range(0f,1f)]
    [SerializeField] float m_elasticity = 90f;

    [Tooltip("If TRUE, the tween will smoothly snap all values to int.")]
    [SerializeField] bool m_snapping = false;

    void Start()
    {
        DOTween.Init();
        StartCoroutine(AnimSequence());
    }

    void PositionPunchAnim()
    {
        transform.DOPunchPosition(
            punch: m_punch,
            duration: m_duration,
            vibrato: m_vibrato,
            elasticity: m_elasticity,
            snapping: m_snapping
        );
    }

    IEnumerator AnimSequence()
    {
        while(true)
        {
            yield return new WaitForSeconds(m_duration + 0.3f);
            PositionPunchAnim();
        }
    }
}
