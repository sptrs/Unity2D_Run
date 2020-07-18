using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    #region 欄位區域
    /*
    // 命名規則
    // 1. 用有意義的名稱
    // 2. 不要使用數字開頭
    // 3. 不要用特殊符號

    // 欄位語法
    // 修飾詞 類型 欄位名稱 =;
    // 沒有 = 值
    // 整數，浮點數，預設值=0
    // 字串 預設值 ''
    // 布林值 false

    // 修飾詞
    // 私人 private - 僅此類別使用 | 不會顯示 - 預設值
    // 公開 public -所有類別使用 | 會顯示
    
    // 欄位屬性 [欄位名稱()]
    // 標題 Header
    // 提示 Tiletip
    // 範圍 Range
    
    // 搬家 Alt + 上，下
    // 格式化 Ctrl + K D
    */



    [Header("速度"), Tooltip("角色速度"), Range(1, 300)]
    public int speed = 50;
    [Header("血量"), Tooltip("角色血量"), Range(10, 1000)]
    public float hp = 500.0f;
    [Header("高度"), Tooltip("角色跳高"), Range(10, 900)]
    public int height = 100;
    [Header("金幣數量"), Tooltip("角色吃了多少金幣")]
    public int coin;
    [Header("音效區域")]
    public AudioClip soundJump;
    public AudioClip soundSlide;
    public AudioClip soundBump;
    public AudioClip soundEatCoin;
    [Header("角色是否死亡"), Tooltip("True 代表死亡，False 表示尚未死亡")]
    public bool dead;
    [Header("動畫觸發器")]
    public Animator ani;
    [Header("膠囊碰撞器")]
    public CapsuleCollider2D cc2d;
    [Header("剛體")]
    public Rigidbody2D rig;
    [Header("金幣數量")]
    public Text TextCoin;
    [Header("血條")]
    public Image imghp;
    [Header("踩地")]
    public bool isGround;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("結束畫面")]
    public GameObject final;
    [Header("過關標題")]
    public Text TextTitle;
    [Header("目前金幣數量")]
    public Text TextCurrent;

    private float hpmax;
    #endregion

    #region 方法區域
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 如果(剛體.加速度.大小 < 8)
        if (rig.velocity.magnitude < 4)
        {
            // 剛體.添加推力(二維向量)
            rig.AddForce(new Vector2(speed, 0));
        }
    }

    /// <summary>
    /// 跳躍功能:跳躍動畫，撥放音效與往上跳
    /// </summary>
    private void Jump()
    {
        bool jump = Input.GetKey(KeyCode.Space);
        

        ani.SetBool("跳躍觸發", !isGround);

        if (isGround)  // 如果在地板上
        {
            if (jump)
            {
                isGround = false; //不再地板上
                rig.AddForce(new Vector2(0, height)); // 剛體.添加推力(二維向量)
                aud.PlayOneShot(soundJump);
            }
        }

    }

    /// <summary>
    /// 滑行功能:滑行動畫，撥放音效，縮小碰撞範圍    
    /// </summary>
    private void Slide()
    {
        //布林值 = 輸入.取得按鍵(按鍵代碼列舉.按鍵)
        bool key = Input.GetKey(KeyCode.LeftControl);

        //動畫控制器代號
        ani.SetBool("滑行觸發", key);

        if (Input.GetKeyDown(KeyCode.LeftControl)) aud.PlayOneShot(soundSlide);

        if (key) // 如果 玩家 按下 按鍵就縮小
        {
            cc2d.offset = new Vector2(0.5f, -0.8f); // 位移
            cc2d.size = new Vector2(1.3f, 1.7f); //尺寸
            aud.PlayOneShot(soundSlide);
        }
        // 否則 恢復
        else
        {
            cc2d.offset = new Vector2(-1.0f, 0.06f); // 位移
            cc2d.size = new Vector2(2.8f, 4.0f); //尺寸
        }
    }

    /// <summary>
    /// 碰到障礙物受傷:扣血
    /// </summary>
    private void Hit(Collider2D collision)
    {
        hp -= 100; // 受傷-100血
        Destroy(collision.gameObject); // 刪掉障礙物
        aud.PlayOneShot(soundBump);
        imghp.fillAmount = hp / hpmax; // 血條.填滿長度 = 血量 / 血量最大值

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 吃金幣:金幣數量增加，更新介面，金幣音效
    /// </summary>
    private void EatCoin(Collider2D collision)
    {
        coin++;  //數量 + 1
        Destroy(collision.gameObject);  // 刪除 (碰撞物件.遊戲物件)
        TextCoin.text = "金幣 : " + coin; // 金幣.文字 = " " + 金幣
        aud.PlayOneShot(soundEatCoin);

    }

    /// <summary>
    /// 死亡:動畫，遊戲結束
    /// </summary>
    private void Dead()
    {
        if (dead) return;

        speed = 0;
        dead = true;
        ani.SetTrigger("死亡觸發");

        final.SetActive(true);    // 啟動設定(是/否)
        TextTitle.text = "不幸你失敗了~";
        TextCurrent.text = "本次的金幣數量 : " + coin;
    }

    /// <summary>
    /// 過關
    /// </summary>
    private void Pass()
    {
        final.SetActive(true);
        TextTitle.text = "恭喜過關了!!";
        TextCurrent.text = "本次的金幣數量 : " + coin;
        speed = 0;
        rig.velocity = Vector3.zero;
    }

    #endregion

    #region 事件區域

    //開始遊戲時觸發
    //初始化
    private void Start()
    {
        hpmax = hp;  
    }

    //更新Update
    //60FPS
    //更新，監聽鍵盤，滑鼠
    private void Update()
    {
        if (dead) return;

        Slide();

        if (transform.position.y <= -6) Dead();
    }


    /// <summary>
    /// 固定更新事件 : 一秒固定執行50次，只要有剛體就寫在這裡
    /// </summary>
    private void FixedUpdate()
    {
        if (dead) return;
        Jump();
        Move();
    }

    /// <summary>
    /// 碰撞事件 : 碰到沒有勾選 Is Trigger 的物件開始執行一次
    /// </summary>
    /// <param name="collision">碰到物件的碰撞資訊</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果 碰到物件 的 名稱 等於 "地板"
        if (collision.gameObject.name == "地板")
        {
            isGround = true; // 在地板上
        }

        // 如果 碰到物件 的 名稱 等於 "地板" 
        if (collision.gameObject.name == "懸空地板" )
        {
            isGround = true;  // 在地板上
        }
    }

    /// <summary>
    /// 觸發事件 : 碰到勾選 Is Trigger 的物件執行一次
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金幣")  // 如果 (碰撞物件.標籤) == ???      
            EatCoin(collision);        

        if(collision.tag == "障礙物")
            Hit(collision);

        if(collision.tag == "尖刺")
            Hit(collision);

        if (collision.name == "傳送門")
            Pass();
    }
    #endregion

}

