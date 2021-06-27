using UnityEngine;

public class ThrowLineRenderer
{
    private readonly LineRenderer _lineRenderer;

    public ThrowLineRenderer(LineRenderer lineRenderer)
    {
        _lineRenderer = lineRenderer;
    }

    public void SetPosition(Vector3 starting, Vector3 ending)
    {
        _lineRenderer.SetPosition(0, ending);
        _lineRenderer.SetPosition(1, starting);
    }

    public void Enable()
    {
        _lineRenderer.enabled = true;
    }

    public void Disable()
    {
        _lineRenderer.enabled = false;
    }
}