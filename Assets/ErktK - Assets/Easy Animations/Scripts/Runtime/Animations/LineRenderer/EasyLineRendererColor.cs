using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(LineRenderer))]
public class EasyLineRendererColor : EasyAnimation
{
    [SerializeField] Color2 m_startColors = new Color2(Color.white, Color.white);
    [SerializeField] Color2 m_endColors = new Color2(Color.black, Color.black);

    private Color m_initialStartColor;
    private Color m_initialEndColor;
    private Color2 m_initialColors;
    private LineRenderer m_lineRenderer;

    void Awake()
    {
        m_lineRenderer = gameObject.GetComponent<LineRenderer>();
        m_initialStartColor = m_lineRenderer.startColor;
        m_initialEndColor = m_lineRenderer.endColor;
        m_initialColors = new Color2(m_initialStartColor, m_initialEndColor);
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_lineRenderer.DOColor(m_startColors, m_endColors, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_lineRenderer.DOColor(m_endColors, m_initialColors, m_duration); // I think I misunderstood how this works. Check this out
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) 
                                {
                                    m_lineRenderer.startColor = m_initialStartColor;
                                    m_lineRenderer.endColor = m_initialEndColor;
                                }

                            });
        return m_tw;
    }
}