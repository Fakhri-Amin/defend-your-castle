using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] AudioClip clickSound;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        FindObjectOfType<Bank>().RestartEverything();
        // StartCoroutine(LoadScene(0));
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadScene(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PlayClickSound();
        FindObjectOfType<Bank>().RestartEverything();
        // StartCoroutine(LoadScene(1));
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void PlayClickSound()
    {
        GetComponent<AudioSource>().PlayOneShot(clickSound);
    }
}
