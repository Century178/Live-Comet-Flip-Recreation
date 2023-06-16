using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Victory());
        }
    }

    private IEnumerator Victory()
    {
        yield return new WaitForSeconds(1.5f); //Adds a delay before going to the next level

        SceneManager.LoadScene(sceneIndex);
    }
}