using UnityEngine;
using DG.Tweening;
using UnityEngine.Audio;

[AddComponentMenu("")]
[RequireComponent(typeof(AudioMixer))]
public class EasyAudioMixerSetFloat : EasyAnimation
{
    [SerializeField] string m_floatName;
    [SerializeField] float m_toFloat;
    private AudioMixer m_audioMixer;
    private float m_initialFloat;

    void Awake()
    {
        m_audioMixer = gameObject.GetComponent<AudioMixer>();
        if(m_audioMixer.GetFloat(m_floatName,  out float value))
        {
            m_initialFloat = value;
        }
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_audioMixer.DOSetFloat(m_floatName, m_toFloat, m_duration)
                        .SetLoops(m_repeat ? -1 : 0, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;
                            if (m_doesReturnHome) m_audioMixer.DOSetFloat(m_floatName, m_initialFloat, m_duration);
                        });

        return m_tw;
    }
}
