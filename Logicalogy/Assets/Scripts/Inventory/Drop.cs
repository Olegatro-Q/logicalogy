using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private movementPlayer movementPlayerScript;
    public float plusToPlayerPosX;
    public float plusToPlayerPosY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movementPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movementPlayer>();
    }

    private void Update()
    {
          
    }

    public void SpawnDroppedItem()
    {
        if(movementPlayerScript.isGrounded == true)
        {
            if (movementPlayerScript.facingRight == true) // это условие, чтобы игрок всегда выкидывал предмет позади себя
            {
                Vector2 playerPos = new Vector2(player.position.x - plusToPlayerPosX, player.position.y + plusToPlayerPosY);
                Instantiate(item, playerPos, Quaternion.identity);
            }
            else
            {
                Vector2 playerPos = new Vector2(player.position.x + plusToPlayerPosX, player.position.y + plusToPlayerPosY);
                Instantiate(item, playerPos, Quaternion.identity);
            }
        }
    }
}
