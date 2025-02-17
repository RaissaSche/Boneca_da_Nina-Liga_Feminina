﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public CanvasFade fade;
    private string nextScene;

    public GameObject mainMenuPanel;
    public GameObject creditsPanel;

    void Start () {
        fade.FadeIn ();
    }

    private void Update () {
        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            ScreenCapture.CaptureScreenshot("Nina.png");
        }*/
    }

    public void OpenScene (string scene) {
        if (fade.Fading)
            return;
        nextScene = scene;
        fade.OnFadeEnd += ChangeScene;
        fade.FadeOut (1f, 0.5f);
    }

    public void QuitGame () {
        Application.Quit ();
    }

    public void LoadDressUp () {
        SceneManager.LoadScene ("DressUp");
    }

    private void ChangeScene (CanvasFade obj, bool fadeIn) {
        SceneManager.LoadScene (nextScene);
    }

    public void CreditsClicked () {
        mainMenuPanel.SetActive (false);
        creditsPanel.SetActive (true);
    }

    public void BackButtonClicked () {
        mainMenuPanel.SetActive (true);
        creditsPanel.SetActive (false);
    }
}