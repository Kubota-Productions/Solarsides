using System.Collections;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform playerRoot; // Change from player to playerRoot
    [SerializeField] private Transform respawnPoint;

    private void Start()
    {
        if (playerRoot == null)
        {
            Debug.LogError("Player root Transform is not assigned.");
        }

        if (respawnPoint == null)
        {
            Debug.LogError("Respawn Point Transform is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer());
        }
    }

    private IEnumerator RespawnPlayer()
    {
        if (playerRoot != null && respawnPoint != null)
        {
            Collider playerCollider = playerRoot.GetComponentInChildren<Collider>(); // Get the collider from the children if needed
            if (playerCollider != null)
            {
                playerCollider.enabled = false;
            }

            playerRoot.position = respawnPoint.position;

            Rigidbody playerRigidbody = playerRoot.GetComponentInChildren<Rigidbody>(); // Get the Rigidbody from the children if needed
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero; // Reset velocity
                playerRigidbody.angularVelocity = Vector3.zero; // Reset angular velocity

                yield return new WaitForEndOfFrame();

                playerRigidbody.MovePosition(respawnPoint.position);
            }

            Physics.SyncTransforms();

            if (playerCollider != null)
            {
                playerCollider.enabled = true;
            }
        }
        else
        {
            Debug.LogWarning("Respawn failed due to missing player root or respawn point.");
        }
    }
}