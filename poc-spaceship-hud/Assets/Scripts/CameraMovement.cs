using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 100.0f;

    private void Update()
    {
        // Translation
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveUpward = 0.0f;
        if (Input.GetKey(KeyCode.Space)) moveUpward = 1.0f;
        if (Input.GetKey(KeyCode.LeftControl)) moveUpward = -1.0f;

        Vector3 movement = new Vector3(moveHorizontal, moveUpward, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotation
        float rotationYaw = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float rotationPitch = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        
        transform.Rotate(Vector3.up, rotationYaw, Space.World);
        transform.Rotate(Vector3.right, rotationPitch, Space.Self);
    }
}
