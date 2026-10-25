using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    private movementPlayer movementPlayerScript;
    public int i;

    private void Start()
    {
        movementPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem() // выкинуть предмет из инвентаря
    {
        if(movementPlayerScript.isGrounded == true) 
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Drop>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
