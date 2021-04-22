using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadManager : MonoBehaviour
{
    public GameObject loadScene;
        public Slider slider;

    public void Loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsy(sceneIndex));
    }

     IEnumerator LoadSceneAsy(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
            {
            loadScene.SetActive(true);
            float progres = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progres;
            yield return null;

            }
    }
}
