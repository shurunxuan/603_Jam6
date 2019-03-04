using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<Transform> players;
    public Vector3 offset;
    public float ScreenAspectRatio;
    public float smoothDamp = 0.5f;
    private Vector3 velocity;
    private void Start()
    {
        Debug.Log(Screen.width + "   " + Screen.height);
        ScreenAspectRatio = (float)Screen.width / (float)Screen.height;
    }
    private void LateUpdate()
    {

        Move();
        Zoom();
    }

    private void Move()
    {
        if (players.Count == 0)
            return;
        Vector3 center = GetCenter();
        center.z = -10;
        transform.position =Vector3.SmoothDamp(transform.position,center,ref velocity,smoothDamp); 
    }
    private void Zoom()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);
        foreach (Transform t in players)
        {
            bounds.Encapsulate(t.position);
        }
        Debug.DrawLine(new Vector3(bounds.min.x, bounds.max.y, 0), new Vector3(bounds.max.x, bounds.min.y, 0));
        Debug.DrawLine(new Vector3(bounds.min.x, bounds.min.y, 0), new Vector3(bounds.max.x, bounds.max.y, 0));
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
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, Time.deltaTime*10);
    }
    public Vector3 GetCenter()
    {
        var bounds = new Bounds(players[0].position, Vector3.zero);

        foreach(Transform t in players)
        {
            bounds.Encapsulate(t.position);
        }
        return bounds.center;
    }

}
