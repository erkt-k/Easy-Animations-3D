using System.Collections;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("True: Tweener updates every frame. (If chosen after Start() is called, doesn't work.)")]
    [SerializeField] bool m_isDynamic = false;
    
    [Tooltip("The position to look at. Towards Object has priority.")]
    [SerializeField] Vector3 m_towards = Vector3.zero;

    [Tooltip("The position to look at. Towards Object has priority.")]
    [SerializeField] Transform m_towardsObject;
    [SerializeField] float m_duration = 0.2f;
    [SerializeField] AxisConstraint m_axisConstrait = AxisConstraint.None;
    [SerializeField] Vector3 m_up = Vector3.up;

    void Start()
    {
        DOTween.Init();
        
        if(!m_isDynamic)
        {
            LookAtAnim();
        }
    }

    void Update()
    {
        if(m_isDynamic)
        {
            DynamicLookAtAnim();
        }
    }

    void LookAtAnim()
    {
        if(m_towardsObject != null) 
                transform.DOLookAt(m_towardsObject.position, m_duration, m_axisConstrait, m_up);
            else 
                transform.DOLookAt(m_towards, m_duration, m_axisConstrait, m_up);
    }

    void DynamicLookAtAnim()
    {
        if(m_towardsObject != null) 
            transform.DODynamicLookAt(m_towardsObject.position, m_duration, m_axisConstrait, m_up);
        else 
            transform.DODynamicLookAt(m_towards, m_duration, m_axisConstrait, m_up);
    }
}

