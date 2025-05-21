using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        playerObject = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
    }
    void OnPauseGame(InputValue value)
    {
        if (isPaused)
        {
            UnPauseGame();
        }
        else
        {
            OnPauseGame();
        }
    }
    public void OnPauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuObject.SetActive(true);
    }
    public void UnPauseGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuObject.SetActive(false);
        ResetPauseUI() ;

    }
    void ResetPauseUI()
    {
        for (int i = 0; i<menuList.transform.childCount; i++)
        {
            menuList.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseStartMenuObject.SetActive(true);
        pauseMenuObject.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
