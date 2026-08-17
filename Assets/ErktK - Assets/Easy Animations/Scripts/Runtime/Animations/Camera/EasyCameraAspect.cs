using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraAspect : EasyAnimation
{
    [SerializeField] float m_toFloat;
    private Camera m_camera;
    private float m_initialAspect;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialAspect = m_camera.aspect;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOAspect(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : 0, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOAspect(m_initialAspect, m_duration);
                    });
        return m_tw;
    }
}
