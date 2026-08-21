using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(ScrollRect))]
public class EasyScrollRectHorizontalNormalizedPos : EasyAnimation
{
    [SerializeField] float m_toHorizontalPos = 0f;

    float m_initialHorizontalPos;
    ScrollRect m_scrollRect;

    void Awake()
    {
        m_scrollRect = GetComponent<ScrollRect>();
        m_initialHorizontalPos = m_scrollRect.horizontalNormalizedPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_scrollRect.DOHorizontalNormalizedPos(m_toHorizontalPos, m_duration, m_snapping)
                        .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;

                            if(m_doesReturnHome) m_scrollRect.DOHorizontalNormalizedPos(m_initialHorizontalPos, m_duration, m_snapping);
                        })
                        .OnKill(() =>
                        {
                            m_tw = null;

                            if (m_doesReturnHome) m_scrollRect.horizontalNormalizedPosition = m_initialHorizontalPos;
                        });

        return m_tw;
    }
}
