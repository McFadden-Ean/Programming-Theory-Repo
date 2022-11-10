using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialScreenUI : MonoBehaviour
{
    public Button titleScreen;
    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
