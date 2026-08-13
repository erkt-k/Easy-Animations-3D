using UnityEngine;
using DG.Tweening;
using UnityEditor.EditorTools;
using UnityEngine.UIElements;
using UnityEngine.Lumin;

[AddComponentMenu("")]
public class EasyTransformScaleXYZ : EasyAnimation
{
    enum AxisOption {X, Y, Z}

    [Tooltip("Which axis to scale?")]
    [SerializeField] AxisOption axisOption = AxisOption.X;

    [Tooltip("The scale to change to.")]
    [SerializeField] float m_toScale = 1f;

    private Vector3 m_initialScale;

    void Awake()
    {
        m_initialScale = transform.localScale;
    }

    public override Tween Play()
    {
        CleanUp();

        switch(axisOption)
        {
            case AxisOption.X:
                m_tw = transform.DOScaleX(m_toScale, m_duration)
                                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                                .OnComplete(() =>
                                {
                                    m_tw = null;
                                    if (m_doesReturnHome) transform.DOScaleX(m_initialScale.x, m_duration);
                                });
                return m_tw;
            case AxisOption.Y:
                m_tw = transform.DOScaleY(m_toScale, m_duration)
                                .SetLoops(m_repeat ? -1 : 0, m_loopType)
                                .OnComplete(() =>
                                {
                                    m_tw = null;
                                    if (m_doesReturnHome) transform.DOScaleY(m_initialScale.y, m_duration);
                                });
                return m_tw;
            case AxisOption.Z:
                m_tw = transform.DOScaleZ(m_toScale, m_duration)
                                .SetLoops(m_repeat ? -1 : 0, m_loopType)
                                .OnComplete(() =>
                                {
                                    m_tw = null;
                                    if (m_doesReturnHome) transform.DOScaleZ(m_initialScale.z, m_duration);
                                });
                return m_tw;
            default:
                return null;
        }
    }
}
