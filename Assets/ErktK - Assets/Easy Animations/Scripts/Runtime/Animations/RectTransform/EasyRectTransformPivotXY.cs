using UnityEngine;
using DG.Tweening;
using EasyAnimationsEnums;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformPivotXY : EasyAnimation
{
    [SerializeField] float m_toPivotPos = 0f;
    [SerializeField] AxisOption2D m_axisOption = AxisOption2D.X;
    private Vector2 m_initialPivotPos;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialPivotPos = m_rectTransform.pivot;
    }

    public override Tween Play()
    {
        CleanUp();

        switch (m_axisOption)
        {
            case AxisOption2D.X:
                m_tw = m_rectTransform.DOPivotX(m_toPivotPos, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOPivotX(m_initialPivotPos.x, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.pivot = m_initialPivotPos;
                            });
                break;
            case AxisOption2D.Y:
                m_tw = m_rectTransform.DOPivotY(m_toPivotPos, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOPivotY(m_initialPivotPos.y, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.pivot = m_initialPivotPos;
                            });
                break;
            default:
                m_tw = null;
                break;
        }
        
        return m_tw;
    }
}
