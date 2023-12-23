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
    public bool isMoving = false; // �����жϽ�ɫ�Ƿ������ƶ�
    public AudioClip footstepSound; // �Ų�����Ч
    [SerializeField]
    SoundManager soundManager;
    public string scenePassword;//����������
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
    public float sprintMultiplier = 4f; // ����ٶȱ�����
    private Rigidbody2D rb;
    private bool isMoving = false; // �����жϽ�ɫ�Ƿ������ƶ�
    private bool isSprinting = false; // �����жϽ�ɫ�Ƿ����ڳ��
    public AudioClip footstepSound; // �Ų�����Ч
    [SerializeField]
    private SoundManager soundManager;
    public string scenePassword; // ����������
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

        // �������ָ��ķ���
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = (mousePos - transform.position).normalized;
        transform.up = lookDirection;
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // �������ָ��ķ�����
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

    // ��ȡ��ɫλ��
    public static Transform GetPlayerPosition()
    {
        return playerTransform;
    }
}
