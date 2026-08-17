using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof(AudioSource))]
public class EasyAudioSourcePitch : EasyAnimation
{
    [SerializeField] float m_toFloat;
    
    private AudioSource m_source;
    private float m_initialFloat;

    void Awake()
    {
        m_source = gameObject.GetComponent<AudioSource>();
        m_initialFloat = m_source.pitch;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_source.DOPitch(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : 0, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_source.DOPitch(m_initialFloat, m_duration);
                    });
        return m_tw;
    }
}
