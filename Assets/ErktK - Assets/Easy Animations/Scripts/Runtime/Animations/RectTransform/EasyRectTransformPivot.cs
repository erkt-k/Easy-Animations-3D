using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformPivot : EasyAnimation
{
    [SerializeField] Vector2 m_toPivotPos = Vector2.zero;
    private Vector2 m_initialPivot;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialPivot = m_rectTransform.pivot;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rectTransform.DOPivot(m_toPivotPos, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOPivot(m_initialPivot, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.pivot = m_initialPivot;
                            });

        return m_tw;
    }
}
