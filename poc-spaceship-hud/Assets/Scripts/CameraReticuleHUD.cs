using UnityEngine;
using TMPro;

public class CameraReticuleHUD : MonoBehaviour
{
    public Camera mainCamera;
    public TMP_Text speedText;
    public TMP_Text orientationText;
    public TMP_Text altitudeText;

    private Vector3 previousCameraPosition;
    private float previousTime;

    private void Start()
    {
        previousCameraPosition = mainCamera.transform.position;
        previousTime = Time.time;
    }

    private void Update()
    {
        UpdateSpeed();
        UpdateOrientation();
        UpdateAltitude();
    }

    private void UpdateSpeed()
    {
        float deltaTime = Time.time - previousTime;
        float distance = Vector3.Distance(mainCamera.transform.position, previousCameraPosition);
        float speed = distance / deltaTime;
        
        speedText.text = string.Format("{0:0.0} m/s", speed);
        
        previousCameraPosition = mainCamera.transform.position;
        previousTime = Time.time;
    }

    private void UpdateOrientation()
    {
        Vector3 eulerAngles = mainCamera.transform.rotation.eulerAngles;
        orientationText.text = string.Format("X: {0:0.0}°\nY: {1:0.0}°\nZ: {2:0.0}°", eulerAngles.x, eulerAngles.y, eulerAngles.z);
    }

    private void UpdateAltitude()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, Vector3.down, out hit))
        {
            float altitude = hit.distance;
            altitudeText.text = string.Format("{0:0.0} m", altitude);
        }
    }
}
