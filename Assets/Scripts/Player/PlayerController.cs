using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 10;
    private StateMachine stateMachine;
    private Idle idleState;
    private Walking walkingState;

    [HideInInspector]
    public Vector2 movementVector;

    void Start() {
        stateMachine = new StateMachine();
        idleState = new Idle(this);
        walkingState = new Walking(this);

        stateMachine.ChangeState(walkingState);
    }

    void Update() {

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
