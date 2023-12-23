using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; // ����TextMeshPro�������ռ�

public class CrossingNumUI : MonoBehaviour
{
    public static CrossingNumUI instance; // ����ʵ��
    public Transform characterHead;
    public TextMeshProUGUI crossingNumText;
    public CharacterData_SO characterData;


    private void Awake()
    {
        Debug.Log("1");
        // ��������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���������������ڳ����л�ʱ��������
        }

      
    }
    private void Update()
    {
        if (characterHead != null)
        {
            float characterCenterX = characterHead.position.x;

      // ��ȡ��ɫ�����y����
        float characterTopY = characterHead.position.y + characterHead.localScale.y * 0.5f;

    // ����UI Text��λ��
    Vector3 uiPosition = new Vector3(characterCenterX, characterTopY +1f, 0f);
    Vector3 screenPosition = Camera.main.WorldToScreenPoint(uiPosition);
    crossingNumText.transform.position = screenPosition;
        

            // ����UI Text���ı�ΪCrossingNum
         /*   crossingNumText.text = "CrossingNum: " + characterData.CrossingNum;*/
        }
    }
}
