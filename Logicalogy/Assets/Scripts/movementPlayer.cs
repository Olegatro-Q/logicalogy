using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    public bool facingRight = true;

    public bool isGrounded; // проверка приземлился ли игрок
    public Transform feetPos; // поз. ног игрока
    public float checkRadius; // насколько близко игрок должен находиться к земле
    public LayerMask whatIsGround; // что мы будем считать за землю
    [SerializeField] private float rayDistance = 0.6f; // длина луча (луч нужен для отслеживания на чём конкретно мы стоим)
    public string platformUnderMe; // некий идентификатор платформы подо мной

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
        
        if(moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        checkPlatform();
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }

        if(isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void checkPlatform() // на чём конкретно мы стоим
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, whatIsGround); // пускаем луч вниз

        if(hit.collider != null) // если луч во что-то упёрся
        {
            if(hit.collider.CompareTag("Platform1"))
            {
                platformUnderMe = "Platform1";
            }
            else if(hit.collider.CompareTag("Platform2"))
            {
                platformUnderMe = "Platform2";
            }
        }
    }

    private void OnDrawGizmos() // встроенная функция для отрисовки чего-либо в РЕДАКТОРЕ СЦЕНЫ (в моём случается используется для отрисовки луча)
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }
}
