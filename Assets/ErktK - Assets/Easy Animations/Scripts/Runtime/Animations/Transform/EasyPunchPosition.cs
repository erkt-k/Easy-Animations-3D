using UnityEngine;
using DG.Tweening;

[AddComponentMenu("")]
public class EasyPunchPosition : EasyAnimation
{

    [Tooltip("The direction and strength of animation in each axis.")]
    [SerializeField] Vector3 m_punch = new Vector3(0f, 0.2f, 0f);

    [Tooltip("How much will the punch vibrate")]
    [SerializeField] int m_vibrato = 10;

    [Tooltip("[0,1] : How much the vector will go beyond the initial positin when bouncing backwards.")]
    [Range(0f,1f)]
    [SerializeField] float m_elasticity = 1f;
    private Vector3 m_initialPos;

    void Awake()
    {
        m_initialPos = transform.position;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = transform.DOPunchPosition(m_punch, m_duration, m_vibrato, m_elasticity, m_snapping)
                        .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;
                            if(m_doesReturnHome) transform.DOMove(m_initialPos, m_duration, m_snapping); 
                        });
        return m_tw;
    }
}