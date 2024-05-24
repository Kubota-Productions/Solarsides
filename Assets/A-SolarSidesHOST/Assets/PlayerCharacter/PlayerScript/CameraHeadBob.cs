using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 1.0f;

    private Quaternion originalRotation;
    private float timer;

    void Start()
    {
        // Store the original local rotation of the camera
        originalRotation = transform.localRotation;
    }

    void Update()
    {
        // Simulate subtle head movement along the x-axis (pitch)
        float bobbingOffset = Mathf.Sin(timer * bobbingSpeed) * bobbingAmount;
        Quaternion bobbingRotation = Quaternion.Euler(bobbingOffset, 0, 0);

        // Combine the bobbing rotation with the original rotation, affecting only pitch
        Quaternion newRotation = originalRotation * bobbingRotation;
        newRotation.eulerAngles = new Vector3(newRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
        transform.localRotation = newRotation;

        // Increment the timer for animation
        timer += Time.deltaTime;
    }
}