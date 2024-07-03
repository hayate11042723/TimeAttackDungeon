using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public string SceneName;

    public int x, y, z;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExitPortal"))
        {
            SceneManager.LoadScene(SceneName); // �����Ŏw�肵���V�[���ɑJ��
        }
    }
}
