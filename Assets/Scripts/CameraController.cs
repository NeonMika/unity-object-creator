using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float CameraSpeedHorizontal = 0.1f;
    public float CameraSpeedRotation = 5.0f;
    public float CameraSpeedVertical = 0.1f;

    // Use this for initialization
    private void Start()
    {
        transform.SetPositionAndRotation(new Vector3(0, 3, -3), Quaternion.AngleAxis(30, new Vector3(1, 0, 0)));
    }

    private void FixedUpdate()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        transform.Translate(hInput * CameraSpeedHorizontal, 0, vInput * CameraSpeedVertical);

        if (Input.GetMouseButton(1))
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            var rotation = new Vector3(0, mouseX * CameraSpeedRotation, 0);
            transform.Rotate(rotation, Space.World);
            rotation = new Vector3(mouseY * CameraSpeedRotation, 0, 0);
            transform.Rotate(rotation, Space.Self);
        }
    }
}