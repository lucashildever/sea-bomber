using UnityEngine;

public class Idle : State {
    
    private PlayerController controller;
    public Idle(PlayerController controller) : base("idle") {
        this.controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("entrou no idle");
    }
    public override void Exit() {
        base.Exit();
        Debug.Log("saiu no idle");
    }
    public override void Update() {
        base.Update();

        if(!controller.movementVector.IsZero()) {
            controller.stateMachine.ChangeState(controller.walkingState);
            return;
        }

    }
    public override void LateUpdate() {
        base.LateUpdate();
    }
    public override void FixedUpdate() {
        base.FixedUpdate();
    }

}