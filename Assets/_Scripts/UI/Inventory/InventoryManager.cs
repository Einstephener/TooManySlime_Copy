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

    public List<InventorySlot> slots = new List<InventorySlot>(); // 슬롯 리스트 (인벤토리에서 슬롯을 관리)
    public int slotCount = 15; // 슬롯의 개수

    private void Start()
    {
        // 슬롯을 slotCount 만큼 생성하여 리스트에 추가
        for (int i = 0; i < slotCount; i++)
        {
            slots.Add(new InventorySlot());
        }
    }

    // 아이템을 인벤토리에 추가하는 함수
    public bool AddItem(WeaponData newItem)
    {
        // 비어있는 슬롯을 찾는다
        foreach (var slot in slots)
        {
            if (!slot.HasItem())
            {
                slot.AddItem(newItem); // 비어있는 슬롯에 아이템 추가
                return true; // 아이템 추가 성공
            }
        }
        return false; // 인벤토리가 꽉 찼을 경우 아이템 추가 실패
    }
}


