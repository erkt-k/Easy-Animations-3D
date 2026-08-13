using UnityEngine;
using DG.Tweening;

[AddComponentMenu("")]
public class EasyTransformJump : EasyAnimation
{
    [Tooltip("Where the jump ends.")]
    [SerializeField] Vector3 m_endValue = Vector3.zero;

    [Tooltip("Power of jump. Max height of Jump is jumpPower + final Y offset.")]
    [Min(0.001f)]
    [SerializeField] float m_jumpPower = 5f;

    [Min(1)]
    [SerializeField] int numberOfJumps = 1;

    private Vector3 m_initialPosition;

    void Awake()
    {
        m_initialPosition = transform.position;
    }

    public override Tween Play()
    {
        return null;
    }

}
