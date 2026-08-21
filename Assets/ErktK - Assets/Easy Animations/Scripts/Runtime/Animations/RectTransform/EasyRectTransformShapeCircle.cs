using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformShapeCircle : EasyAnimation
{
    [SerializeField] Vector2 m_circleCenter = Vector2.zero;
    [SerializeField] float m_endValueDegrees = 180f;
    [SerializeField] bool m_relativeCenter = false;
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

        m_tw = m_rectTransform.DOShapeCircle(m_circleCenter, m_endValueDegrees, m_duration, m_relativeCenter, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos(m_initialAnchorPos, m_duration, m_snapping);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.anchoredPosition = m_initialAnchorPos;
                            });

        return m_tw;
    }
}
