using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Mask: MonoBehaviour
{
    public Transform maskTransform; // 这里改成 Transform 类型
    private bool isMaskVisible = false; // 初始状态为无遮罩
    private float transitionDuration = 0.1f;

    private float currentCooldown = 0f;
    private bool isTransitioning = false;
    private float transitionStartTime;
    private static GameManager gameManager; // 静态引用


    void Start()
    {
        // 初始状态为无遮罩
        SetMaskAlpha(0f);
        gameManager = GameManager.instance;
    }

    void Update()
    {
        // 检查CD是否已结束
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }

        // 检测空格键且没有在过渡中并且CD结束
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning && currentCooldown <= 0f)
        {
            isTransitioning = true;
            transitionStartTime = Time.time;

            // 切换遮罩层的透明度
            isMaskVisible = !isMaskVisible;
       
        }

        // 如果正在过渡中
        if (isTransitioning)
        {
            // 计算过渡的进度
            float progress = (Time.time - transitionStartTime) / (transitionDuration);

            // 调整透明度
            float alpha = Mathf.Lerp(isMaskVisible ? 0f : 1f, isMaskVisible ? 1f : 0f, progress);
            SetMaskAlpha(alpha);
            
            // 如果过渡完成
            if (progress >= 1.0f)
            {
                isTransitioning = false;
               
            }
        }

        // 获取鼠标指向的方向
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        // 计算旋转角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 设置遮罩层的旋转和位置
        maskTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        maskTransform.position = transform.position;
    }

    void SetMaskAlpha(float alpha)
    {
        Color maskColor = maskTransform.GetComponent<SpriteRenderer>().color;
        maskColor.a = alpha;
        maskTransform.GetComponent<SpriteRenderer>().color = maskColor;

        // 调用函数，将当前的遮罩层引用传递给 GameManager
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
