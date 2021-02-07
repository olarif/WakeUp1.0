using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("1-1 A Clockwork");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
