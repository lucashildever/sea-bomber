using UnityEngine;

public class Walking : State
{
    private PlayerController controller;
    public Walking(PlayerController controller) : base("walking") {
        this.controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("entrou no walking");
    }
    public override void Exit() {
        base.Exit();
        Debug.Log("saiu no walking");
    }
    public override void Update() {
        base.Update();

        bool isUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    
        float movementZ = isUp ? 1 : isDown ? -1 : 0;
        float movementX = isRight ? 1 : isLeft ? -1 : 0;

        Vector3 movementVector = new Vector3(movementX, 0, movementZ);

        controller.transform.Translate(movementVector * controller.movementSpeed * Time.deltaTime);


    }
    public override void LateUpdate() {
        base.LateUpdate();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}