

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
      

        // 获取当前角色状态
        CharacterState currentState = characterData.currentState;

        // 根据角色状态执行逻辑
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