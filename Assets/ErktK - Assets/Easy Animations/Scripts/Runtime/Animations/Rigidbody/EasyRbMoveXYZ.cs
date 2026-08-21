using UnityEngine;
using DG.Tweening;
using EasyAnimationsEnums;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody))]
public class EasyRbMoveXYZ : EasyAnimation
{
    [SerializeField] float m_toPos = 0f;
    [SerializeField] AxisOption3D m_axisOption = AxisOption3D.X;

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

        switch (m_axisOption)
        {
            case AxisOption3D.X:
                m_tw = m_rb.DOMoveX(m_toPos, m_duration, m_snapping)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DOMoveX(m_initialPos.x, m_duration, m_snapping);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.position = m_initialPos;
                });
                break;
            case AxisOption3D.Y:
                m_tw = m_rb.DOMoveY(m_toPos, m_duration, m_snapping)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DOMoveY(m_initialPos.y, m_duration, m_snapping);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.position = m_initialPos;
                });
                break;
            case AxisOption3D.Z:
                m_tw = m_rb.DOMoveZ(m_toPos, m_duration, m_snapping)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.DOMoveZ(m_initialPos.z, m_duration, m_snapping);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.position = m_initialPos;
                });
                break;
            default:
                m_tw = null;
                break; 
        }
        return m_tw;
    }
}
