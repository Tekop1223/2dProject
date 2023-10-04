using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler Instance;

    void Awake()
    {
        Debug.Log("this is called");
        if (Instance == null)
            Instance = this;

        if (Instance != null)
            Destroy(this);
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(changeSceneRoutine(index));
    }

    IEnumerator changeSceneRoutine(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }
}
