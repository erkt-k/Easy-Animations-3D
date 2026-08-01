using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] bool repeat = true;
    [Tooltip("The angle to rotate to. It uses vector3 not Quaternion angles.")]
    [SerializeField] Vector3 m_toAngle = Vector3.zero;
    [SerializeField] float m_duration = 0.2f;
    [SerializeField] RotateMode m_rotateMode = RotateMode.Fast;

    void Start()
    {
        StartCoroutine(AnimSequence());
    }

    void RotateAnim()
    {
        transform.DORotate(m_toAngle, m_duration, m_rotateMode);
    }

    IEnumerator AnimSequence()
    {
        do
        {
            RotateAnim();
            yield return new WaitForSeconds(m_duration + 0.2f);
        } while(repeat);
    }
}
