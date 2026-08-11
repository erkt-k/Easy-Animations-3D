using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyTransformMove : EasyAnimation
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
        m_initialPos = transform.position;
    }


    /// <summary>
    /// Plays the tweener. If tweener doesn't exist, creates the tweener first.
    /// </summary>
    /// <returns>
    /// The tweener or Null if there is a problem with the MoveOption choice.
    /// </returns>
    public override Tween Play()
    {
        if (m_tw != null)
        {
            m_tw.Kill();
            m_tw = null;
        }

        switch(m_moveOption)
        {
            case MoveOption.V3:
                m_tw = transform.DOMove(m_toPosition, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOMove(m_initialPos, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            case MoveOption.Transform:
                m_tw = transform.DOMove(m_toTransform.position, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;
                                if (m_doesReturnHome)
                                {
                                    transform.DOMove(m_initialPos, m_duration, m_snapping);
                                }
                            });
                return m_tw;
            default:
                return null;
        }
    }
}
