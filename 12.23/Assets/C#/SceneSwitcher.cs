using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private void Start()
    {

    }
    public string targetSceneName = "First";
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
            {
            Destroy(other.gameObject);
            // �������ֹ����������Ϊ���ڼ����³���ʱ������
            GameObject musicManager = GameObject.Find("Sound"); 
            if (musicManager != null)
            {
                DontDestroyOnLoad(musicManager);
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
            }
    
    }
}

