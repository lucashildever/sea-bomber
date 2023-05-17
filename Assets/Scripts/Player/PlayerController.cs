using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    [HideInInspector] public Rigidbody myRigidBody;
    public float movementSpeed = 10;
    public float jumpHeight = 5f;
    private float jumpCoolDown = 1f;
    
    [HideInInspector] public StateMachine stateMachine;
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Walking walkingState;
    [HideInInspector] public Vector2 movementVector;

    private void Awake() {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void Start() {
        stateMachine = new StateMachine();
        idleState = new Idle(this);
        walkingState = new Walking(this);

        stateMachine.ChangeState(idleState);
        // stateMachine.ChangeState(walkingState);
    }

    void Update() {

        bool isJumping = Input.GetKey(KeyCode.Space);

        jumpCoolDown -= Time.deltaTime;

        if(isJumping && jumpCoolDown <= 0) {
            myRigidBody.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            jumpCoolDown = 1f;
        }
 
        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);

        float inputX = isRight ? 1 : isLeft ? -1 : 0;
        float inputY = isUp ? 1 : isDown ? -1 : 0;

        movementVector = new Vector2(inputX, inputY);

        stateMachine.Update();
    }
}
