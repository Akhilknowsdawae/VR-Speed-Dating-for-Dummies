using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transition;

    public void GoToCafeScene()
    {
        StartCoroutine(CrossfadeTransition("MainSceneCafe"));        
    }
    public void GoToSuccessScene()
    {
        //SceneManager.LoadScene("SuccessScene");
        SceneManager.LoadScene(1);
    }
    public void GoToFailureScene()
    {
        //SceneManager.LoadScene("FailureScene");
        SceneManager.LoadScene(2);
    }
    public void GoToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void ExitGame()
    {
        Debug.Log("Exiting game!");
        Application.Quit();
    }

    IEnumerator CrossfadeTransition(string sceneToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneToLoad);
    }

}
