using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public string ThreeSections;
    public string FreeFall;
    public string ParabolicMotion;
    public string HorizontalMotion;
    public string StartMenu;
    public void LoadSceneToThreeSections()
    {
        SceneManager.LoadScene("ThreeSections");
    }
    public void LoadSceneToFreeFall()
    {
        SceneManager.LoadScene("FreeFall");
    }
    public void LoadSceneToParabolicMotion()
    {
        SceneManager.LoadScene("ParabolicMotion");
    }
    public void LoadSceneToHorizontalMotion()
    {
        SceneManager.LoadScene("HorizontalMotion");
    }

    public void LoadSceneToBACK()
    {
        SceneManager.LoadScene("StartMenu");
    }
}