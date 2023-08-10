using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartTrial() {
        SceneManager.LoadScene("Game");
    }

    public void QuitApp() {
        Application.Quit();
    }
}
