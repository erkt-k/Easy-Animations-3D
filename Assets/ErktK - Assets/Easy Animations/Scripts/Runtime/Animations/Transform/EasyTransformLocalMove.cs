using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyTransformLocalMove : EasyAnimation
{

    enum MoveOption {V3, Transform}

    [Tooltip("Which will be used to move?")]
    [SerializeField] MoveOption m_moveOption = MoveOption.V3;

    [Tooltip("The position to move to.")]
    [SerializeField] Vector3 m_toPosition = Vector3.zero;

    [Tooltip("The transform to move to.")]
    [SerializeField] Transform m_toTransform;

    private Vector3 m_initialPos;

    void Awake()
    {
        m_initialPos = transform.localPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        switch(m_moveOption)
        {
            case MoveOption.V3:
                m_tw = transform.DOLocalMove(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOLocalMove(m_initialPos, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case MoveOption.Transform:
                m_tw = transform.DOLocalMove(m_toTransform.localPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOLocalMove(m_initialPos, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            default:
                return null;
        }
    }
}
