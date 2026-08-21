using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Graphic))]
public class EasyGraphicFade : EasyAnimation
{
    [SerializeField] float m_toAlpha = 0f;
    private Color m_initialColor;
    private Graphic m_graphic;

    void Awake()
    {
        m_graphic = gameObject.GetComponent<Graphic>();
        m_initialColor = m_graphic.color;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_graphic.DOFade(m_toAlpha, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_graphic.DOFade(m_initialColor.a, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_graphic.color = m_initialColor;
                            });

        return m_tw;
    }
}
