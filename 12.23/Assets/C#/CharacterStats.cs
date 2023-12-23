using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStats : MonoBehaviour
{
    //用于获取角色数值
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
        // 切换角色状态
        characterData.currentState = (characterData.currentState == CharacterState.Normal) ?
            CharacterState.Masked : CharacterState.Normal;

        // 执行其他根据状态变化需要进行的操作...

        // 例如，可以通过检查角色状态来改变遮罩层的逻辑
        if (characterData.currentState == CharacterState.Masked)
        {
            // 执行遮罩层启用的逻辑...
        }
        else
        {
            // 执行遮罩层禁用的逻辑...
        }
    }



}