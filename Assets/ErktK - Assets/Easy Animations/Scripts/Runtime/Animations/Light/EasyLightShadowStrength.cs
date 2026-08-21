using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Light))]
public class EasyLightShadowStrength : EasyAnimation
{
    [SerializeField] float m_toStrength = 0f;
    private float m_initialStrength;
    private Light m_light;

    void Awake()
    {
        m_light = gameObject.GetComponent<Light>();
        m_initialStrength = m_light.shadowStrength;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_light.DOShadowStrength(m_toStrength, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_light.DOShadowStrength(m_initialStrength, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_light.shadowStrength = m_initialStrength;
                    });
        return m_tw;
    }
}
