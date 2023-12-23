using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTime = 0.3f; // 缓动时间，可在Inspector中调整
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // 获取角色位置
        Transform target = PlayerMovement.GetPlayerPosition();

        if (target != null)
        {
            // 计算摄像头目标位置
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 使用SmoothDamp函数实现缓动效果
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}