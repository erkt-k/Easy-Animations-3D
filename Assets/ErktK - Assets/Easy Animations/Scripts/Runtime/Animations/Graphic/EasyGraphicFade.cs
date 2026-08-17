using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Graphic))]
public class EasyGraphicFade : EasyAnimation
{
    [SerializeField] float m_toFloat = 0f;
    private float m_initialFloat;
    private Graphic m_graphic;

    void Awake()
    {
        m_graphic = gameObject.GetComponent<Graphic>();
        m_initialFloat = m_graphic.color.a;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_graphic.DOFade(m_toFloat, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_graphic.DOFade(m_initialFloat, m_duration);
                            });

        return m_tw;
    }
}
