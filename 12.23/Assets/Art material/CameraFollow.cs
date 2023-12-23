using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTime = 0.3f; // ����ʱ�䣬����Inspector�е���
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // ��ȡ��ɫλ��
        Transform target = PlayerMovement.GetPlayerPosition();

        if (target != null)
        {
            // ��������ͷĿ��λ��
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // ʹ��SmoothDamp����ʵ�ֻ���Ч��
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}