using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public float minZoom = 3f;
    public float maxZoom = 10f;
    public float zoomSpeed = 1f;
    public float smoothTime = 0.2f;
    private Camera cam;
    public float targetZoom;
    public float zoomVelocity = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
        targetZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f) {
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoom, ref zoomVelocity, smoothTime);
    }
}
