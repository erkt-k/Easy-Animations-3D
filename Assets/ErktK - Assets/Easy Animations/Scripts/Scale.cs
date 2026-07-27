using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Scale : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Does the animation repeat?")]
    [SerializeField] bool repeat = true;
    [Tooltip("The scale to change to. Has priority over uniform value.")]
    [SerializeField] Vector3 m_toScale = Vector3.zero;

    [Tooltip("Scales uniformly. Vector3 other than 0, has priority.")]
    [SerializeField] float m_toScaleUniformly;

    [Tooltip("Duration of the movement.")]
    [SerializeField] float m_duration = 0.5f;

    [Tooltip("True: Returns to initial scale.")]
    [SerializeField] bool doesReturnNormal = false;
    private Vector3 m_initialScale;

    void Start()
    {
        m_initialScale = transform.localScale;
        DOTween.Init();
        StartCoroutine(AnimRoutine());
    }

    void MoveAnimation()
    {
        if(!m_toScale.Equals(Vector3.zero)) // Does the vector have a value?
        {
            transform.DOScale(m_toScale, m_duration);
        } else
        {
            if(m_toScale != null)
            {
                transform.DOScale(m_toScaleUniformly, m_duration);
            }
        }
    }

    IEnumerator AnimRoutine()
    {
        do
        {
            MoveAnimation();
            if (doesReturnNormal)
            {
                yield return new WaitForSeconds(m_duration);
                transform.DOScale(m_initialScale, m_duration);
            }
            yield return new WaitForSeconds(m_duration + 0.2f);
        } while(repeat);
    }
}
