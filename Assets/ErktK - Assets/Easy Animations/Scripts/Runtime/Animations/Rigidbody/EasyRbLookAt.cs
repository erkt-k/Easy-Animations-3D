using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody))]
public class EasyRbLookAt : EasyAnimation
{
    [SerializeField] Vector3 m_posToLook = Vector3.zero;
    [SerializeField] AxisConstraint m_axisConstraint = AxisConstraint.None;
    [SerializeField] Vector3 m_up = Vector3.up; 
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

        m_tw = m_rb.DOLookAt(m_posToLook, m_duration, m_axisConstraint, m_up)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DORotate(m_initialRot, m_duration);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.rotation = Quaternion.Euler(m_initialRot);
                });
        return m_tw;
    }
}
