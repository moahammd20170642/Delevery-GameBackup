using UnityEngine;

public class CarCameraController : MonoBehaviour
{
   public DeleveryManager deleveryManager;
    public Transform car; // Reference to the car's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Adjust the camera offset

    public float smoothSpeed = 0.5f; // Adjust the smoothness of camera movement
    public float rotationSpeed = 5f; // Adjust the rotation speed

    private void Start()
    {
        car = deleveryManager.cars[PlayerPrefs.GetInt(prefs.SelectedCar, 0)].transform;
    }
    void LateUpdate()
    {
        if (car == null)
        {
            Debug.LogWarning("Car reference not set for the camera controller.");
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = car.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera position
        transform.position = smoothedPosition;

        // Rotate the camera to look at the car smoothly
        Quaternion desiredRotation = Quaternion.LookRotation(car.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
