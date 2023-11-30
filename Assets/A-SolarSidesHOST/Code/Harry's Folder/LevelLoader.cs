using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{    
    [SerializeField] string SceneName;
    [SerializeField] RawImage fadeImage;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(fade());
        }
    }

    IEnumerator fade() {
        for (float i = 0; i <= 1.05f; i += 0.05f) {
            fadeImage.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.05f);
        }

        SceneManager.LoadSceneAsync(SceneName);
    }
}
