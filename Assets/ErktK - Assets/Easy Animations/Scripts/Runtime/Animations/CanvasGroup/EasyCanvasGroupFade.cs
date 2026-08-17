using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(CanvasGroup))]
public class EasyCanvasGroupFade : EasyAnimation
{
    [SerializeField] float m_toFloat = 0f;
    private float m_initialFloat;
    private CanvasGroup m_canvasGroup;

    void Awake()
    {
        m_canvasGroup = gameObject.GetComponent<CanvasGroup>();
        m_initialFloat = m_canvasGroup.alpha;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_canvasGroup.DOFade(m_toFloat, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_canvasGroup.DOFade(m_initialFloat, m_duration);
                            });

        return m_tw;
    }
}
