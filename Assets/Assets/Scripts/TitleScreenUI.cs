using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button tutorialButton;
    [SerializeField] Button quitButton;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_InputField nameInput;
    private string mTextInput;
    public string textInput //ENCAPSULATION
    {
        get { return mTextInput; }
        set
        {
            if (mTextInput.Length > 8)
            {
                Debug.LogError("That name is too long!");
            }
            else
            {
                mTextInput = value;
            }
        }
    }

    private void Start()
    {
        MainManager.Instance.LoadHighScore();

        if(MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                bestScoreText.text = "Try and get a high score!";
            }
        }
    }
    public void SavePlayerName()
    {
        mTextInput = nameInput.text;
        MainManager.Instance.sessionName = textInput;
    }
    void DisplayHighScore()
    {
        bestScoreText.text = "The current high score is " + MainManager.Instance.highScore + " set by " + MainManager.Instance.highName;
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
            Application.Quit();
    #endif
    }

}
