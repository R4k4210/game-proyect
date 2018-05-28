using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GeneralManager gameManager;
    private float xAxis;
    private float yAxis;
    private float moveSpeed=1;
    private List<int> comboChain;
    private float speedFactor;
    Rigidbody2D rigid;
    Animator anim;

    public enum Horizontal { left,right}
    public enum Vertical { up,down}
    public enum Axis { Horizontal,Vertical}

    // Use this for initialization
    void Start () {
        gameManager = GetComponent<GeneralManager>();
        //rigid is the main character being controlled by this manager, to affect other entities modify this. Probably will need refactoring in future versions.
        rigid = gameManager.player.GetComponent<Rigidbody2D>();
        anim = gameManager.player.GetComponent<Animator>();
    }

    public void GetVerticalInput(Vertical input) {
        if (input == Vertical.up) {
            yAxis = 1;
        } else if (input == Vertical.down) {
            yAxis = -1;
        }
    }

    public void ResetVerticalInput() {
        yAxis = 0;
    }

    public void GeHorizontalInput(Horizontal input) {
        if (input == Horizontal.right) {
            xAxis = 1;
        } else if (input == Horizontal.left) {
            xAxis = -1;
        }
    }

    public void ResetHorizontalInput() {
        xAxis = 0;
    }

    private float GetAxis(Axis axis)
    {
        float retorno = 0;
#if UNITY_ANDROID
                switch (axis){
            case Axis.Horizontal:
                retorno = xAxis;
                break;
            case Axis.Vertical:
                retorno = yAxis;
                break;
        }
#endif
#if UNITY_STANDALONE
        switch (axis)
        {
            case Axis.Horizontal:
                retorno = Input.GetAxis("Horizontal");
                break;
            case Axis.Vertical:
                retorno = Input.GetAxis("Vertical");
                break;
        }
#endif
        return retorno;
    }

    private int GetDirection()
    {
        //Make the movement weight 1, if it is 0, u cant see the movement.
        anim.SetLayerWeight(1, 1);

        if (GetAxis(Axis.Horizontal) > 0)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
            anim.SetInteger("Direction", 2);
        }else if(GetAxis(Axis.Horizontal) < 0)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
            anim.SetInteger("Direction", 4);
        }
        if (GetAxis(Axis.Vertical) > 0)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
            anim.SetInteger("Direction", 1);
        }
        else if (GetAxis(Axis.Vertical) < 0)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Idle", false);
            anim.SetInteger("Direction", 3);
        }
        if(GetAxis(Axis.Horizontal) == 0 && GetAxis(Axis.Vertical) == 0)
        {
            anim.SetLayerWeight(1, 0);
            anim.SetBool("Walking", false);
            anim.SetBool("Idle", true);
        }

        return 1;
    }

    private void MoveHorizontal(float movement){
        rigid.velocity = new Vector2(movement * moveSpeed, rigid.velocity.y);
    }

    private void MoveVertical(float movement){
        rigid.velocity = new Vector2(rigid.velocity.x,movement * moveSpeed);
    }

    private void StopHorizontal() {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }

    private void StopVertical() {
        rigid.velocity = new Vector2(rigid.velocity.x,0);
    }


    private void MovementManager(int movementType)
    {
        speedFactor = (gameManager.player.transform.localScale.x + gameManager.player.transform.localScale.y)/2;
        moveSpeed = gameManager.player.GetComponent<CharacterEntity>().Velocidad*speedFactor;
        //Use case 4, ignore other cases.
        switch (movementType)
        {
            case 1:
#region "case 1"
                if (Input.GetButton("Run/walk"))
                {
                    moveSpeed *= (Input.GetAxis("Run/walk"));
                }
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    gameManager.player.transform.Translate(Input.GetAxis("Horizontal") * moveSpeed, 0, 0);
                    gameManager.player.transform.Translate(0, Input.GetAxis("Vertical") * moveSpeed, 0);
                }
#endregion
                break;
            case 2:
#region "case 2"
                if (Input.GetButton("Run/walk"))
                {
                    moveSpeed += (Input.GetAxis("Run/walk") * speedFactor) *1.5f;
                }
                if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0));
                    gameManager.player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,Input.GetAxis("Vertical") * moveSpeed));
                    //gamemanager.player.transform.Translate(Input.GetAxis("Horizontal") * movespeed, 0, 0);
                    //gamemanager.player.transform.Translate(0, Input.GetAxis("Vertical") * movespeed, 0);
                }
                if (Input.GetButtonUp("Horizontal"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameManager.player.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (Input.GetButtonUp("Vertical"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(gameManager.player.GetComponent<Rigidbody2D>().velocity.x ,0);
                }
#endregion
                break;
            case 3:
#region "case 3"
                if (Input.GetButton("Run/walk"))
                {
                    moveSpeed += Input.GetAxis("Run/walk") * speedFactor;
                }
                if (Input.GetButton("Vertical"))
                {MoveVertical(Input.GetAxis("Vertical"));/*gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(gameManager.player.GetComponent<Rigidbody2D>().velocity.x, Input.GetAxis("Vertical") * moveSpeed);*/}
                if (Input.GetButton("Horizontal"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, gameManager.player.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (Input.GetButtonUp("Horizontal"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameManager.player.GetComponent<Rigidbody2D>().velocity.y);
                }
                if (Input.GetButtonUp("Vertical"))
                {
                    gameManager.player.GetComponent<Rigidbody2D>().velocity = new Vector2(gameManager.player.GetComponent<Rigidbody2D>().velocity.x, 0);
                }
#endregion
                break;
            case 4:
                GetDirection();
                MoveHorizontal(GetAxis(Axis.Horizontal));
                MoveVertical(GetAxis(Axis.Vertical));
                
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        MovementManager(4);
	}
}
