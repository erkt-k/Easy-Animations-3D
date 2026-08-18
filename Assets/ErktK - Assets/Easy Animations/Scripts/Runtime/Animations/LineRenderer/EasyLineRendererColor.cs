using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(LineRenderer))]
public class EasyLineRendererColor : EasyAnimation
{
    [SerializeField] Color2 m_startColors = new Color2(Color.white, Color.white);
    [SerializeField] Color2 m_endColors = new Color2(Color.black, Color.black);

    private LineRenderer m_lineRenderer;

    void Awake()
    {
        m_lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_lineRenderer.DOColor(m_startColors, m_endColors, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_lineRenderer.DOColor(m_endColors, m_startColors, m_duration);
                            });
        return m_tw;
    }
}