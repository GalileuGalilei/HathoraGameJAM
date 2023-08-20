using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverHUD;
    [SerializeField]
    GameObject PauseHUD;
    [SerializeField]
    GameObject CongratsHUD;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseHUD.activeSelf)
            {
                PauseHUD.SetActive(false);
            }
            else
            {
                PauseHUD.SetActive(true);
            }
        }
    }

    public void GameOver()
    {
        GameOverHUD.SetActive(true);
        
        //do something to frozen players...
        Time.timeScale = 0;
    }

    public void Congrats()
    {
        CongratsHUD.SetActive(true);

        //do something to frozen players...
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Disconnect()
    {
        //sabe se la deus como...
    }

    public void LoadScene(int scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
