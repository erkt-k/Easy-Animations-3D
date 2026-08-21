using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(ScrollRect))]
public class EasyScrollRectVerticalPos : EasyAnimation
{
    [SerializeField] float m_toVerticalPos = 0f;

    float m_initialVerticalPos;
    ScrollRect m_scrollRect;

    void Awake()
    {
        m_scrollRect = GetComponent<ScrollRect>();
        m_initialVerticalPos = m_scrollRect.verticalNormalizedPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_scrollRect.DOVerticalNormalizedPos(m_toVerticalPos, m_duration, m_snapping)
                        .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;

                            if(m_doesReturnHome) m_scrollRect.DOVerticalNormalizedPos(m_initialVerticalPos, m_duration, m_snapping);
                        })
                        .OnKill(() =>
                        {
                            m_tw = null;

                            if (m_doesReturnHome) m_scrollRect.verticalNormalizedPosition = m_initialVerticalPos;
                        });

        return m_tw;
    }
}
