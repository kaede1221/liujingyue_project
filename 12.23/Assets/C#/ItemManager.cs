using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;
    public enum ItemType
    {
        Item1,
        Item2,
        Item3,
        Item4
        // ���Ը���ʵ�������Ӹ���ĵ�������
    }
    public static ItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject("ItemManager");
                    _instance = go.AddComponent<ItemManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }

    // ʹ���ֵ�洢����ʰȡ״̬
    private Dictionary<ItemType, bool> itemCollected = new Dictionary<ItemType, bool>();

    // ��ȡ����ʰȡ״̬�ķ���
    public bool GetItemCollected(ItemType itemType)
    {
        // ����ֵ��а����������ͣ��򷵻ض�Ӧ��ʰȡ״̬�����򷵻�false
        return itemCollected.TryGetValue(itemType, out bool collected) ? collected : false;
    }

    // ���õ���ʰȡ״̬�ķ���
    public void SetItemCollected(ItemType itemType, bool value)
    {
        // ����ֵ��а����������ͣ������ʰȡ״̬����������µĵ������ͺ�״̬
        if (itemCollected.ContainsKey(itemType))
        {
            itemCollected[itemType] = value;
        }
        else
        {
            itemCollected.Add(itemType, value);
        }
    }

    public bool IsItemCollected(ItemType itemType)
    {
        return GetItemCollected(itemType);
    }
}
