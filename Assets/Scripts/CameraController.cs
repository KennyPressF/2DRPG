using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCam;
    [SerializeField] float camPanSpeed;
    [SerializeField] float camZoomSpeed;

    Vector2 targetPos;
    bool isMoving = false;

    private void Start()
    {
        mainCam = this.gameObject.GetComponent<Camera>();
    }

    public void PanCamera(Vector2 inputVector)
    {
        targetPos = (Vector2)transform.position + inputVector;
        isMoving = true;
    }

    void Update()
    {
        PanCamera();
        ScrollCamera();
    }

    private void PanCamera()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * camPanSpeed * Time.deltaTime;
        float yAxisValue = Input.GetAxis("Vertical") * camPanSpeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + yAxisValue, transform.position.z);
    }

    private void ScrollCamera()
    {
        mainCam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
    }
}
