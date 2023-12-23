using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Mask: MonoBehaviour
{
    public Transform maskTransform; // ����ĳ� Transform ����
    private bool isMaskVisible = false; // ��ʼ״̬Ϊ������
    private float transitionDuration = 0.1f;

    private float currentCooldown = 0f;
    private bool isTransitioning = false;
    private float transitionStartTime;
    private static GameManager gameManager; // ��̬����


    void Start()
    {
        // ��ʼ״̬Ϊ������
        SetMaskAlpha(0f);
        gameManager = GameManager.instance;
    }

    void Update()
    {
        // ���CD�Ƿ��ѽ���
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }

        // ���ո����û���ڹ����в���CD����
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning && currentCooldown <= 0f)
        {
            isTransitioning = true;
            transitionStartTime = Time.time;

            // �л����ֲ��͸����
            isMaskVisible = !isMaskVisible;
       
        }

        // ������ڹ�����
        if (isTransitioning)
        {
            // ������ɵĽ���
            float progress = (Time.time - transitionStartTime) / (transitionDuration);

            // ����͸����
            float alpha = Mathf.Lerp(isMaskVisible ? 0f : 1f, isMaskVisible ? 1f : 0f, progress);
            SetMaskAlpha(alpha);
            
            // ����������
            if (progress >= 1.0f)
            {
                isTransitioning = false;
               
            }
        }

        // ��ȡ���ָ��ķ���
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        // ������ת�Ƕ�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �������ֲ����ת��λ��
        maskTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        maskTransform.position = transform.position;
    }

    void SetMaskAlpha(float alpha)
    {
        Color maskColor = maskTransform.GetComponent<SpriteRenderer>().color;
        maskColor.a = alpha;
        maskTransform.GetComponent<SpriteRenderer>().color = maskColor;

        // ���ú���������ǰ�����ֲ����ô��ݸ� GameManager
        SetGameManagerMask(this);
    }
    private static void SetGameManagerMask(Mask newMask)
    {
        if (gameManager != null)
        {
            gameManager.mask = newMask;
        }
        else
        {
            Debug.LogWarning("GameManager is null. Make sure GameManager is properly set up.");
        }
    }




}
