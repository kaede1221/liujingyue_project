using UnityEngine;

public enum CharacterState
{
    Normal,
    Masked,
    // �������״̬...
}

[CreateAssetMenu(fileName = "New Data", menuName = "Character Stats/Data")]
public class CharacterData_SO : ScriptableObject
{
    [Header("Stats Info")]
    // ���������ɫ����...

    [Header("State Info")]
    public CharacterState currentState = CharacterState.Normal;
}

/*public class YourPlayerController : MonoBehaviour
{
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
}*/
