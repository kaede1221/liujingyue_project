/*using System.Diagnostics.CodeAnalysis;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterData_SO characterData;
    public static PlayerMovement instance;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public bool isMoving = false; // 用于判断角色是否正在移动
    public AudioClip footstepSound; // 脚步声音效
    [SerializeField]
    SoundManager soundManager;
    public string scenePassword;//出生点设置
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        
        }
        else
        {
            if (instance != this)
            {   Destroy(gameObject);
           
            }
        }
        DontDestroyOnLoad(gameObject);
     
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        
        MoveandJump();
    }

    private void MoveandJump()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2();
        movement.x = horizontalInput * moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            movement.y = jumpForce;
          
        }
        if (Mathf.Abs(horizontalInput) > 0.1f && movement.y < 0.1f && movement.y > -0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        rb.velocity = movement;
    }



    public bool GETifplayerMoving()
    {
        return isMoving;
    }
}
*/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterData_SO characterData;
    public static PlayerMovement instance;
    public float moveSpeed = 5f;
    public float sprintMultiplier = 4f; // 冲刺速度倍增器
    private Rigidbody2D rb;
    private bool isMoving = false; // 用于判断角色是否正在移动
    private bool isSprinting = false; // 用于判断角色是否正在冲刺
    public AudioClip footstepSound; // 脚步声音效
    [SerializeField]
    private SoundManager soundManager;
    public string scenePassword; // 出生点设置
    public static GameManager Instance { get; private set; }

    private static Transform playerTransform;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Sprint();
        SetPlayerPosition(transform);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2();
        movement.x = horizontalInput * moveSpeed;
        movement.y = verticalInput * moveSpeed;

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        rb.velocity = movement;

        // 面向鼠标指针的方向
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = (mousePos - transform.position).normalized;
        transform.up = lookDirection;
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // 向着鼠标指向的方向冲刺
            rb.velocity = transform.up * moveSpeed * sprintMultiplier;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    public bool GetIfPlayerMoving()
    {
        return isMoving;
    }

    public bool GetIfPlayerSprinting()
    {
        return isSprinting;
    }

    public void SetPlayerPosition(Transform player)
    {
        playerTransform = player;
    }

    // 获取角色位置
    public static Transform GetPlayerPosition()
    {
        return playerTransform;
    }
}
