using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Light))]
public class EasyLightIntensity : EasyAnimation
{
    [SerializeField] float m_toIntensity = 0f;
    private float m_initialIntensity;
    private Light m_light;

    void Awake()
    {
        m_light = gameObject.GetComponent<Light>();
        m_initialIntensity = m_light.intensity;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_light.DOIntensity(m_toIntensity, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_light.DOIntensity(m_initialIntensity, m_duration);
                    });
        return m_tw;
    }
}
