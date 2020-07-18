using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("追蹤腳色")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 5;
    [Header("攝影機Y軸限制")]
    public Vector2 limitY = new Vector2(0, 3.5f);

    private void Track()
    {
        Vector3 a = transform.position; // A = 攝影機
        Vector3 b = target.position; // B = 目標
        b.z = -10; // Z軸 - 10

        a = Vector3.Lerp(a, b, Time.deltaTime * speed);  // 插值(A , B , 百分比)

        a.y = Mathf.Clamp(a.y, limitY.x, limitY.y);  // a.y = 數學函式.夾住(a.y ,最小 , 最大) 

        transform.position = a;  //設定攝影機座標
    }

    private void LateUpdate()
    {
        Track();
    }
}
