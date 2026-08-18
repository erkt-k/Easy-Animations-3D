using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorPos3DXYZ : EasyAnimation
{
    enum AxisOption {X, Y, Z}
    [SerializeField] float m_toAnchorPos = 0f;
    [SerializeField] AxisOption m_axisOption = AxisOption.X;
    private Vector3 m_initialAnchorPos;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialAnchorPos = m_rectTransform.anchoredPosition3D;
    }

    public override Tween Play()
    {
        CleanUp();

        switch (m_axisOption)
        {
            case AxisOption.X:
                m_tw = m_rectTransform.DOAnchorPos3DX(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos3DX(m_initialAnchorPos.x, m_duration, m_snapping);
                            });
                break;
            case AxisOption.Y:
                m_tw = m_rectTransform.DOAnchorPos3DY(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos3DY(m_initialAnchorPos.y, m_duration, m_snapping);
                            });
                break;
            case AxisOption.Z:
                m_tw = m_rectTransform.DOAnchorPos3DZ(m_toAnchorPos, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos3DZ(m_initialAnchorPos.z, m_duration, m_snapping);
                            });
                break;
            default:
                m_tw = null;
                break;
        }
        
        return m_tw;
    }
}
