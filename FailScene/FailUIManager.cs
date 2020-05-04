using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailUIManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject snowPlane;

    public AudioSource failAudioSource;
    public AudioClip buttonClip;


    private void Update()
    {
        if (snowPlane.transform.position.y >= 0.5)
        {
            canvas.gameObject.SetActive(true);
        }
    }

    public void ChangeToPlayScene()
    {
        failAudioSource.PlayOneShot(buttonClip);
        SceneManager.LoadScene("MainScene");
    }

}
