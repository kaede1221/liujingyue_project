using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStats : MonoBehaviour
{
    //���ڻ�ȡ��ɫ��ֵ
    public CharacterData_SO characterData;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleCharacterState();
        }
    }

    void ToggleCharacterState()
    {
        // �л���ɫ״̬
        characterData.currentState = (characterData.currentState == CharacterState.Normal) ?
            CharacterState.Masked : CharacterState.Normal;

        // ִ����������״̬�仯��Ҫ���еĲ���...

        // ���磬����ͨ������ɫ״̬���ı����ֲ���߼�
        if (characterData.currentState == CharacterState.Masked)
        {
            // ִ�����ֲ����õ��߼�...
        }
        else
        {
            // ִ�����ֲ���õ��߼�...
        }
    }



}