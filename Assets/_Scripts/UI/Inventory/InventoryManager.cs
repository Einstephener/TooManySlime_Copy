using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    private static bool _initialized;

    #region Singleton
    public static InventoryManager Instance
    {
        get
        {
            if (_initialized) return _instance;
            _initialized = true;

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;

                if (_instance == null)
                    Debug.Log("No Singleton");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public List<InventorySlot> slots = new List<InventorySlot>(); // ���� ����Ʈ (�κ��丮���� ������ ����)
    public int slotCount = 15; // ������ ����

    private void Start()
    {
        // ������ slotCount ��ŭ �����Ͽ� ����Ʈ�� �߰�
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    // �������� �κ��丮�� �߰��ϴ� �Լ�
    public bool AddItem(WeaponData newItem)
    {
        // ����ִ� ������ ã�´�
        foreach (var slot in slots)
        {
            if (!slot.HasItem())
            {
                slot.AddItem(newItem); // ����ִ� ���Կ� ������ �߰�
                return true; // ������ �߰� ����
            }
        }
        return false; // �κ��丮�� �� á�� ��� ������ �߰� ����
    }
}


