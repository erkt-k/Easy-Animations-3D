using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraOrthoSize : EasyAnimation
{
    [SerializeField] float m_toFloat;
    private Camera m_camera;
    private float m_initialOrthoSize;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialOrthoSize = m_camera.orthographicSize;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOOrthoSize(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOOrthoSize(m_initialOrthoSize, m_duration);
                    });
        return m_tw;
    }
}
