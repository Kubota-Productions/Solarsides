using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;
    public float dayLength = 120f; // Length of a day in seconds

    void Update()
    {
        float angleThisFrame = Time.deltaTime / dayLength * 360;
        directionalLight.transform.Rotate(Vector3.right, angleThisFrame);
    }
}
