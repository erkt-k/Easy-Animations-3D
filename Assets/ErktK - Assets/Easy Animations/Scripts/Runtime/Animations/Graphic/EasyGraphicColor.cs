using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[AddComponentMenu(""), RequireComponent(typeof(Graphic))]
public class EasyGraphicColor : EasyAnimation
{
    [SerializeField] Color m_toColor = Color.white;

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

        m_tw = m_graphic.DOColor(m_toColor, m_duration)
                        .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;

                            if (m_doesReturnHome) m_graphic.DOColor(m_initialColor, m_duration);
                        });

        return m_tw;
    }
}
