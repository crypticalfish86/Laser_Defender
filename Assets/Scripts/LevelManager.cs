using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }
    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad(2, 2));
    }

    public void QuitGame(){
        Debug.Log("Quitting game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float waitTime){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
