

using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public CharacterData_SO characterData;
    private SpriteRenderer mapRenderer;

    void Start()
    {
        mapRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
      

        // ��ȡ��ǰ��ɫ״̬
        CharacterState currentState = characterData.currentState;

        // ���ݽ�ɫ״ִ̬���߼�
        if (currentState == CharacterState.Normal)
        {
            SetMapAlpha(0);
        }
        else if (currentState == CharacterState.Masked)
        {
            SetMapAlpha(255);
        }
    }

    void SetMapAlpha(float alpha)
    {
        Color mapColor = mapRenderer.color;
        mapColor.a = alpha;
        mapRenderer.color = mapColor;
    }
}