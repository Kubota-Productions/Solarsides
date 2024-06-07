using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool cursorActive = true; // Flag to track cursor state
    public Camera playerCamera; // Reference to the player camera
    public Camera thirdPersonCamera; // Reference to the third-person camera

    private Quaternion playerCameraOriginalRotation; // Store original rotation of the player camera

    void Start()
    {
        // Store the original rotation of the player camera
        if (playerCamera != null)
        {
            playerCameraOriginalRotation = playerCamera.transform.rotation;
        }
    }

    void Update()
    {
        // Check if cursor should be active or not based on menu state
        if (cursorActive)
        {
            // Activate and confine cursor within the game window
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            // Deactivate and lock cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Ensure the player camera doesn't move with the cursor
        if (playerCamera != null && cursorActive)
        {
            // Reset the player camera rotation to the original rotation
            playerCamera.transform.rotation = playerCameraOriginalRotation;
        }
    }

    // Method to be called when menu becomes active
    public void ActivateMenu()
    {
        cursorActive = true;
    }

    // Method to be called when menu becomes inactive
    public void DeactivateMenu()
    {
        cursorActive = false;
    }

    // Method to be called when resuming game (e.g., from pause menu)
    public void ResumeGame()
    {
        // Clear the flag to ensure cursor becomes inactive and locked during next Update
        cursorActive = false;
    }
}