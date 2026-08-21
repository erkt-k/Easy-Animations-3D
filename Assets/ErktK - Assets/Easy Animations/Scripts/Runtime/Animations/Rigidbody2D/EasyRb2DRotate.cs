using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody2D))]
public class EasyRb2DRotate : EasyAnimation
{
    [SerializeField] float m_toRot = 0f;
    private float m_initialRot;
    private Rigidbody2D m_rb;

    void Awake()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_initialRot = m_rb.rotation;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rb.DORotate(m_toRot, m_duration)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DORotate(m_initialRot, m_duration);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.rotation = m_initialRot;
                });
        return m_tw;
    }
}
