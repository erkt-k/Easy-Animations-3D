using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody))]
public class EasyRbMove : EasyAnimation
{
    [SerializeField] Vector3 m_toPos = Vector3.zero;

    private Vector3 m_initialPos;
    private Rigidbody m_rb;

    void Awake()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_initialPos = transform.position;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rb.DOMove(m_toPos, m_duration, m_snapping)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DOMove(m_initialPos, m_duration, m_snapping);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.position = m_initialPos;
                });
        return m_tw;
    }
}
