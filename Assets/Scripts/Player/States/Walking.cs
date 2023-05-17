using UnityEngine;

public class Walking : State {

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

        if(controller.movementVector.IsZero()) {
            controller.stateMachine.ChangeState(controller.idleState);
            return;
        }

        Vector3 walkVector = new Vector3(controller.movementVector.x, 0, controller.movementVector.y);
        walkVector *= controller.movementSpeed * Time.deltaTime;

        controller.myRigidBody.AddForce(walkVector, ForceMode.Impulse);
    }
    public override void LateUpdate() {
        base.LateUpdate();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
    }
}