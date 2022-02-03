using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigitbody;//コンポーネントを入れる箱を用意？
    private ParticleSystem myParticle;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    private float velocityY = 10f;
    private float movableRange = 3.4f;
    private float coefficient = 0.99f;
    private bool isEnd = false;
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown = false;




    // Start is called before the first frame update
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigitbody = GetComponent<Rigidbody>();
        this.myParticle = GetComponent<ParticleSystem>();
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;//入力時の値であるthis.velocityZに0.99を掛け算する
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        float inputVelocityX = 0;//左右の入力が無い時、横方向の速度を0
        float inputVelocityY = 0;//縦方向の速度を入れる入れ物を宣言
        if ((Input.GetKey(KeyCode.LeftArrow)||this.isLButtonDown) && -this.movableRange < this.transform.position.x)//左矢印＆X方向-3.4の時
        {
            inputVelocityX = -this.velocityX;//X方向の速度に-10fを代入
        }
        else if ((Input.GetKey(KeyCode.RightArrow)|| this.isRButtonDown) && this.transform.position.x < this.movableRange)//右矢印＆X方向3.4の時
        {
            inputVelocityX = this.velocityX;//X方向の速度に10fを代入
        }
        if((Input.GetKeyDown(KeyCode.Space)||this.isJButtonDown)&& this.transform.position.y < 0.5f)//スペースキーの入力＆高さ0.5以上　　GetKeyDown押された時　GetKey押されている間 
        {
            this.myAnimator.SetBool("Jump", true);
            inputVelocityY = this.velocityY;
        }
        else
        {
            inputVelocityY = this.myRigitbody.velocity.y;//0よりこっちが優先、滑らかなジャンプになる？
        }
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }

            this.myRigitbody.velocity = new Vector3(inputVelocityX,inputVelocityY, this.velocityZ);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CarTag"|| other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "CLEAR!!";

        }
        if (other.gameObject.tag == "CoinTag")
        {
            this.score += 10;
            this.scoreText.GetComponent<Text>().text = "Score" + this.score + "pt";
            this.myParticle.Play();
            Destroy(other.gameObject);
        }
    }
    public void getMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void getMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void getMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void getMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
