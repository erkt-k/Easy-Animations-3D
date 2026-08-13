using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyPunchRotation : EasyAnimation
{
    [Tooltip("The direction and strength of animation in each axis.")]
    [SerializeField] Vector3 m_punch = new Vector3(0f, 0.2f, 0f);

    [Tooltip("How much will the punch vibrate")]
    [SerializeField] int m_vibrato = 10;

    [Tooltip("[0,1] : How much the vector will go beyond the initial positin when bouncing backwards.")]
    [Range(0f,1f)]
    [SerializeField] float m_elasticity = 1f;
    private Vector3 m_initialRot;

    void Awake()
    {
        m_initialRot = transform.rotation.eulerAngles;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = transform.DOPunchRotation(m_punch, m_duration, m_vibrato, m_elasticity)
                        .SetLoops(m_repeat ? -1 : 0, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;
                            if(m_doesReturnHome) transform.DORotate(m_initialRot, m_duration);
                        });
        return m_tw;
    }
}