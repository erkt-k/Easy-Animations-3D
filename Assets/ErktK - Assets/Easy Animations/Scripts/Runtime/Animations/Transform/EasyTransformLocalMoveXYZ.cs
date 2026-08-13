using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyTransformLocalMoveXYZ : EasyAnimation
{

    enum AxisOption {X, Y, Z}

    [Tooltip("Which axis to move in?")]
    [SerializeField] AxisOption axis = AxisOption.X;

    [Tooltip("The position to move to.")]
    [SerializeField] float m_toPosition = 0f;

    private Vector3 m_initialPos;

    void Awake()
    {
        m_initialPos = transform.localPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        switch(axis)
        {
            case AxisOption.X:
                m_tw = transform.DOLocalMoveX(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOLocalMoveX(m_initialPos.x, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case AxisOption.Y:
                m_tw = transform.DOLocalMoveY(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOLocalMoveY(m_initialPos.y, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case AxisOption.Z:
                m_tw = transform.DOLocalMoveZ(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOLocalMoveZ(m_initialPos.z, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            default:
                return null;
        }
    }
}
