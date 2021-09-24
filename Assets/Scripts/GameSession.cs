using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] AudioClip pauseSFX;
    [SerializeField] AudioSource bgMusic;
    bool isActive = false;
    bool playMusic = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
        }
        ShowOptionCanvas();
    }

    void ShowOptionCanvas()
    {
        if (!pauseCanvas) return;

        if (isActive)
        {
            pauseCanvas.SetActive(true);
            bgMusic.mute = true;
            if (!playMusic)
            {
                GetComponent<AudioSource>().PlayOneShot(pauseSFX);
                playMusic = true;
            }
            Time.timeScale = 0;
        }
        else
        {
            playMusic = false;
            bgMusic.mute = false;
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
    }


}
