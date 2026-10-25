using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;
    public Image IconShowHideInv;
    public Sprite[] MassivOfIcons; // 0 - icon hide // 1 - icon show

    private void Start()
    {
        inventoryOn = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ShowHideInventory();
        }
    }

    public void ShowHideInventory()
    {
        if (inventoryOn == false) // инвентарь ВКЛючится
        {
            inventoryOn = true;
            inventory.SetActive(true);
            IconShowHideInv.sprite = MassivOfIcons[0];
        }
        else if (inventoryOn == true) // инвентарь ВЫКЛючится
        {
            inventoryOn = false;
            inventory.SetActive(false);
            IconShowHideInv.sprite = MassivOfIcons[1];
        }
        }
    }

