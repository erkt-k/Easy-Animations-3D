using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Slider))]
public class EasySliderValue : EasyAnimation
{
    [SerializeField] float m_toValue = 0f;
    private float m_initialValue;
    private Slider m_slider;

    void Awake()
    {
        m_slider = gameObject.GetComponent<Slider>();
        m_initialValue = m_slider.value;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_slider.DOValue(m_toValue, m_duration, m_snapping)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_slider.DOValue(m_initialValue, m_duration, m_snapping);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;
                        if (m_doesReturnHome) m_slider.value = m_initialValue;
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_slider.value = m_initialValue;
                    });

        return m_tw;
    }
}
