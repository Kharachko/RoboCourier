using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerStateMachine stateMachine;
        private Rigidbody rb;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            stateMachine = gameObject.AddComponent<PlayerStateMachine>();

            stateMachine.RegisterState(PlayerState.Idle, new IdleState(rb));
            stateMachine.RegisterState(PlayerState.Walking, new WalkingState(rb));
            stateMachine.RegisterState(PlayerState.Jumping, new JumpingState(rb));

            stateMachine.SetInitialState(PlayerState.Idle);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                stateMachine.SetJumping(true);
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                stateMachine.SetWalking(true);
            else
            {
                stateMachine.SetWalking(false);
                stateMachine.SetJumping(false);
            }
        }
    }
}
