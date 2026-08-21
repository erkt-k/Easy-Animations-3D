using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformPunchAnchorPos : EasyAnimation
{
    [SerializeField] Vector2 m_punch = Vector2.one;
    [SerializeField] int m_vibrato = 10;
    [SerializeField, Range(0f,1f)] float m_elasticity = 1f;
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

        m_tw = m_rectTransform.DOPunchAnchorPos(m_punch, m_duration, m_vibrato, m_elasticity, m_snapping)
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
