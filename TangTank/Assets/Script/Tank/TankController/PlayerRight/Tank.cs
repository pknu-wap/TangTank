using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour {
    private Animator tankMove;
    public float moveSpeed = 5f;
    public GameObject sp;
    public float jumpSpeed = 5f;
    public bool isGrounded = false;
    Rigidbody rb;
    private Quaternion Up = Quaternion.identity;
    public Slider healthBarSlider;  //reference for slider
    private bool isGameOver = false; //flag to see if game is over
    public GameObject gameOver;
    private bool isMoving=false;


    // Use this for initialization
    void Start () {
        tankMove = GetComponent<Animator>();
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody>();
        gameOver.SetActive(false);
        tankMove.SetBool("isDied", false);
	}

    public void IsMoved()
    {

    tankMove.SetBool("isMoved", isMoving);

    }

    public void TankJump()
    {
        if (isGrounded)
        {
            // 입력키가 위화살표면 실행함
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // 위방향으로 올라가게함
                rb.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);

                // 점프하면 isGrounded가 false
                isGrounded = false;

                // false 안바꾸면 무한점프됨
                // isGround를 숫자로하면 n단 점프도 가능
            }
        }
    }
    public void MoveLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localRotation.eulerAngles.y != 0)
            {
                Up.eulerAngles = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.Slerp(transform.rotation, Up, 1);
            }
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            isMoving = true;
        }

    }

    public void MoveRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.localRotation.eulerAngles.y !=180)
            {
                Up.eulerAngles = new Vector3(0, 180, 0);
                transform.localRotation = Quaternion.Slerp(transform.rotation, Up, 1);
            }
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            isMoving = true;
        }

    }


    private void OnCollisionEnter(Collision col)
    {
        // Ground에 닿으면 isGround는 true
        // gameObject 는 Plane
        if (col.gameObject.tag == "Ground")
            isGrounded = true;

        if (col.gameObject.tag == "Shell")
        {
            //피격 연출
            //체력바 깎음
            //UI 
            Debug.Log("맞았습니다");
            if (healthBarSlider.value > 0)
            {
                healthBarSlider.value -= 0.25f;  //reduce health

            }
            else
            {
                sp.transform.position = gameObject.transform.position;
                gameObject.SetActive(false);
                sp.SetActive(true);
                gameOver.SetActive(true);

            }
        }
    }

    IEnumerator dieTime()
    {
        yield return new WaitForSeconds(2);
    }


    // Update is called once per frame
    void Update () {
        IsMoved();
        TankJump();
        MoveLeft();
        MoveRight();
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) isMoving = false;
        

    }

}
