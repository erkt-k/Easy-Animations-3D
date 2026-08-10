using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("")]
public class PunchRotation : MonoBehaviour
{
    [Header("Animation Properties")]
    [SerializeField] bool m_repeat = true;

    [Tooltip("The direction and strength of animation in each axis.")]
    [SerializeField] Vector3 m_punch = new Vector3(0f, 0.2f, 0f);

    [Tooltip("How long the animation is")]
    [SerializeField] float m_duration = 0.8f;

    [Tooltip("How much will the punch vibrate")]
    [SerializeField] int m_vibrato = 10;

    [Tooltip("[0,1] : How much the vector will go beyond the initial positin when bouncing backwards.")]
    [Range(0f,1f)]
    [SerializeField] float m_elasticity = 1f;
    private Tweener tw;

    void Start()
    {   
        Applym_repeat();
    }

    void Applym_repeat()
    {
        if (tw != null) transform.DOKill(true);  

        
        int loopAmnt = m_repeat ? -1 : 0;      
        tw = transform.DOPunchRotation(
            m_punch, 
            m_duration, 
            m_vibrato, 
            m_elasticity).SetLoops(loopAmnt, LoopType.Restart);
    }

    void OnValidate()
    {
        Applym_repeat();
        Debug.Log("m_repeat : " + m_repeat);
    }
}