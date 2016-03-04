using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    public float ifDie;
    public AudioClip deadAudio; //死亡音效
    public AudioClip jumpAudio; //跳跃音效
    public Text livesText;

    private int playTimes;      //复活次数

    public GameObject respawn; //重生点
    private Vector3 respawnPos;
    public float force_move = 50;
    public float jumpVelocity = 10;
    private Animator anim;
    private bool isGround = false;
    private  bool isWall = false;//是否在墙上
    private bool isSlide = false;

    private Transform wallTrans;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
        playTimes = 30;
        respawnPos = respawn.transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (!isSlide)
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

            if (h > 0.05f)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * force_move);
            }
            else if (h < -0.05f)
            {
                GetComponent<Rigidbody2D>().AddForce(-Vector2.right * force_move);
            }

            //修改朝向
            if (h > 0.05f)
            {//朝向右方向
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (h < -0.05f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetFloat("horizontal", Mathf.Abs(h));

            if (isGround && Input.GetButton("Jump"))
            {
                AudioManager._instance.PlaySingle(jumpAudio);
                velocity.y = jumpVelocity;
                GetComponent<Rigidbody2D>().velocity = velocity;
                if (isWall)
                {
                    GetComponent<Rigidbody2D>().gravityScale = 5;
                }
            }

            anim.SetFloat("vertical", GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            //当我们在墙上滑行的时候
       
        }

        if (isWall == false || isGround == true)
        {
            isSlide = false;
        }


    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            isGround = true;
            GetComponent<Rigidbody2D>().gravityScale = 30;
        }
        if (col.collider.tag == "Wall")
        {
            isWall = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 5;
            wallTrans = col.collider.transform;
        }
        anim.SetBool("isGround", isGround);
        anim.SetBool("isWall", isWall);


        if (col.transform.tag == "Enemy")
        {
            ifDie = this.transform.position.y-col.transform.position.y ;
            if (ifDie < 3.56)
            {
                AudioManager._instance.PlaySingle(deadAudio);
                Dead();
            }
            else
            {
                Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
                velocity.y = jumpVelocity;
                GetComponent<Rigidbody2D>().velocity = velocity;
            }
            
        }
        if (col.transform.tag == "Dead")
        {
            AudioManager._instance.PlaySingle(deadAudio);
            Dead();
        }

        if (col.transform.tag== "Respawn")
        {
            respawnPos = col.transform.position;
        }
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            isGround = false;
        }
        if (col.collider.tag == "Wall")
        {
            isWall = false;
            GetComponent<Rigidbody2D>().gravityScale = 30;
        }
        anim.SetBool("isGround", isGround);
        anim.SetBool("isWall", isWall);

        if (col.collider.tag == "Finish")
        {
            GameController._instance.FinishLevel();
        }
    }
    //更改朝向
    public void ChangeDir()
    {
        isSlide = true;
        if (wallTrans.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    //角色死亡
    public void Dead()
    {
        if (playTimes > 0)
        {
            playTimes--;
            respawnPos.y = respawnPos.y + 1;
            GetComponent<Transform>().position = respawnPos;
            livesText.text = "Lives: " + playTimes;
            GameController._instance.SetScore(0);

        }
        else
        {
            GameController._instance.GameOver();
        }
    }


}
