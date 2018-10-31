using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public void ChangeScene(int sceneNumber)
    {
        Debug.Log("Change Scene Button Pressed");
        Scene previousScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(GameObject.Find("Player"), SceneManager.GetSceneByBuildIndex(sceneNumber));
        SceneManager.UnloadSceneAsync(previousScene.buildIndex);
    }
}
