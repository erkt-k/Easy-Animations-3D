using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorPosXY : EasyAnimation
{
    enum AxisOption {X, Y}
    [SerializeField] float m_toAnchorPos = 0f;
    [SerializeField] AxisOption m_axisOption = AxisOption.X;
    private Vector2 m_initialAnchorPos;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialAnchorPos = m_rectTransform.anchoredPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        switch (m_axisOption)
        {
            case AxisOption.X:
                m_tw = m_rectTransform.DOAnchorPosX(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPosX(m_initialAnchorPos.x, m_duration, m_snapping);
                            });
                break;
            case AxisOption.Y:
                m_tw = m_rectTransform.DOAnchorPosY(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPosY(m_initialAnchorPos.y, m_duration, m_snapping);
                            });
                break;
            default:
                m_tw = null;
                break;
        }
        
        return m_tw;
    }
}
