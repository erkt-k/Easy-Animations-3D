using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Light))]
public class EasyLightColor : EasyAnimation
{
    [SerializeField] Color m_toColor = Color.white;
    private Color m_initialColor;
    private Light m_light;

    void Awake()
    {
        m_light = gameObject.GetComponent<Light>();
        m_initialColor = m_light.color;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_light.DOColor(m_toColor, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_light.DOColor(m_initialColor, m_duration);
                    });
        return m_tw;
    }
}
