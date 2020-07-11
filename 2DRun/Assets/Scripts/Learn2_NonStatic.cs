using UnityEngine;

public class Learn2_NonStatic : MonoBehaviour
{
    // 儲存場景上的物件或元件
    public GameObject dino;

    public Transform dinotran;

    public Camera cam;

    public ParticleSystem ps;

    //靜態和非靜態差別
    //非靜態需要有物件與元件

    // 存取 
    // 非靜態屬性

    private void Start()
    {
        //取得
        print(dino.tag);
        print(dino.layer);

        //存放
        dinotran.position = new Vector3(-5.5f, 3, 0);
    }

    private void Update()
    {
        // 非靜態方法
        dinotran.Translate(0.01f, 0, 0);
    }
}
