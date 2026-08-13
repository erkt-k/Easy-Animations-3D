using DG.Tweening;
using UnityEditor.EditorTools;
using UnityEngine;

[AddComponentMenu("")]
public class EasyTransformMoveXYZ : EasyAnimation
{

    enum AxisOption {X, Y, Z}

    [Tooltip("Which axis to move in?")]
    [SerializeField] AxisOption axis = AxisOption.X;

    [Tooltip("The position to move to.")]
    [SerializeField] float m_toPosition = 0f;

    private Vector3 m_initialPos;

    void Awake()
    {
        m_initialPos = transform.position;
    }

    public override Tween Play()
    {
        CleanUp();
        switch(axis)
        {
            case AxisOption.X:
                m_tw = transform.DOMoveX(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOMoveX(m_initialPos.x, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case AxisOption.Y:
                m_tw = transform.DOMoveY(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOMoveY(m_initialPos.y, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case AxisOption.Z:
                m_tw = transform.DOMoveZ(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOMoveZ(m_initialPos.z, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            default:
                return null;
        }
    }
}
