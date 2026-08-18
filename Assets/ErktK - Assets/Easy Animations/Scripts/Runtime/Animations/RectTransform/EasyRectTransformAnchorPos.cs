using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorPos : EasyAnimation
{
    [SerializeField] Vector2 m_toAnchorPos = Vector2.zero;
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

        m_tw = m_rectTransform.DOAnchorPos(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos(m_initialAnchorPos, m_duration, m_snapping);
                            });

        return m_tw;
    }
}
