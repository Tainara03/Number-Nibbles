using UnityEngine;

public class GyroCamera : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroEnabled = false;
    private Quaternion rotationFix;

    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            rotationFix = Quaternion.Euler(90f, 0f, -90f);

            return true;
        }

        return false;
    }

    void Update()
    {
        if (!gyroEnabled) return;

        transform.localRotation = rotationFix * gyro.attitude;
    }
}
