using UnityEngine;

public class FuDongEff2 : MonoBehaviour
{
    Vector3 trans1;//记录原位置
    Vector2 trans2;//简谐运动变化的位置，计算得出

    public float zhenFu = 10f;//振幅
    public float HZ = 1f;//频率

    private void Awake()
    {
        trans1 = transform.position;
    }

    private void Update()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;

        transform.position = trans2;
    }
}
