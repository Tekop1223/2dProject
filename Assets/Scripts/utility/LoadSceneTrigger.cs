using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] private int _sceneToLoadIndex;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("et eller andet");
        if (other.CompareTag("Player"))
            SceneHandler.Instance.ChangeScene(_sceneToLoadIndex);

    }
}
