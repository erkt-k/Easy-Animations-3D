using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof(AudioSource))]
public class EasyAudioSourcePitch : EasyAnimation
{
    [SerializeField] float m_toPitch;
    
    private AudioSource m_source;
    private float m_initialPitch;

    void Awake()
    {
        m_source = gameObject.GetComponent<AudioSource>();
        m_initialPitch = m_source.pitch;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_source.DOPitch(m_toPitch, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_source.DOPitch(m_initialPitch, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_source.pitch = m_initialPitch;
                    });
        return m_tw;
    }
}
