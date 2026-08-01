using System.Collections;
using DG.Tweening;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Does the animation m_repeat?")]
    [SerializeField] bool m_repeat = true;
    [Tooltip("The position to move to. Has priority over transform")]
    [SerializeField] Vector3 m_toPosition = Vector3.zero;

    [Tooltip("The transform to move to. The vector has priority over this value")]
    [SerializeField] Transform m_toTransform;

    [Tooltip("Duration of the movement.")]
    [SerializeField] float m_duration = 0.5f;

    [Tooltip("True: the movement will smoothly snap to integer values.")]
    [SerializeField] bool m_snapping = false;

    [Tooltip("True: Returns to initial position.")]
    [SerializeField] bool doesReturnHome = false;
    private Vector3 m_initialPosition;

    void Start()
    {
        m_initialPosition = transform.position;
        StartCoroutine(AnimRoutine());
    }

    void MoveAnimation()
    {
        if(!m_toPosition.Equals(Vector3.zero)) // Does the vector have a value?
        {
            transform.DOMove(m_toPosition, m_duration, m_snapping);
        } else
        {
            if(m_toTransform != null)
            {
                transform.DOMove(m_toTransform.position, m_duration, m_snapping);
            }
        }
    }

    IEnumerator AnimRoutine()
    {
        do
        {
            MoveAnimation();
            
            if (doesReturnHome)
            {
                yield return new WaitForSeconds(m_duration);
                transform.DOMove(m_initialPosition, m_duration, m_snapping);
            }
            yield return new WaitForSeconds(m_duration + 0.2f);
        } while(m_repeat);
    }
}
