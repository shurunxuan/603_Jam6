using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<InputController> players;
    public Vector3 offset;
    public float ScreenAspectRatio;
    public float smoothDamp = 0.5f;
    private Vector3 velocity;
    private void Start()
    {
        ScreenAspectRatio = (float)Screen.width / (float)Screen.height;
    }
    private void LateUpdate()
    {
        Vector3 center;
        float zoom;
        SetCamera(out center,out zoom);
        Move(center, zoom);

    }

    private void Move(Vector3 center, float zoom)
    {
        if (players.Count == 0)
            return;
        center.z = -10;
        transform.position =Vector3.SmoothDamp(transform.position,center,ref velocity,smoothDamp);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoom, Time.deltaTime * 10);
    }
    private void SetCamera(out Vector3 center,out float zoom)
    {
        var bounds = new Bounds(players[0].LastKnownPosition, Vector3.zero);
        foreach (InputController t in players)
        {
            bounds.Encapsulate(t.LastKnownPosition);
        }
        //Debug.DrawLine(new Vector3(bounds.min.x, bounds.max.y, 0), new Vector3(bounds.max.x, bounds.min.y, 0));
        //Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, 0), new Vector3(bounds.max.x, bounds.max.y, 0));

        center = bounds.center;
        float bufferx = bounds.size.x + 2;
        float buffery = bounds.size.y + 2;
        float boundsAspectRatio = (bufferx ) / (buffery);
        float targetSize;
        if (boundsAspectRatio <= ScreenAspectRatio)
        {
            targetSize = buffery / 2;
        }
        else
        {
            targetSize = (bufferx /  ScreenAspectRatio) / 2f;
        }
        zoom = targetSize;
       
    }

}
