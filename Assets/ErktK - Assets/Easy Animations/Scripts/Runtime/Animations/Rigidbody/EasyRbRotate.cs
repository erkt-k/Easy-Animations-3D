using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody))]
public class EasyRbRotate : EasyAnimation
{
    [SerializeField] Vector3 m_toRot = Vector3.zero;
    [SerializeField] RotateMode m_rotateMode = RotateMode.Fast;
    private Vector3 m_initialRot;
    private Rigidbody m_rb;

    void Awake()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_initialRot = m_rb.rotation.eulerAngles;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rb.DORotate(m_toRot, m_duration, m_rotateMode)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DORotate(m_initialRot, m_duration, m_rotateMode);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.rotation = Quaternion.Euler(m_initialRot);
                });
        return m_tw;
    }
}
