using UnityEngine;

namespace Player
{
    public class IdleState : BaseState<PlayerState>
    {
        private Rigidbody rb;

        public IdleState(Rigidbody rigidbody) : base(PlayerState.Idle)
        {
            rb = rigidbody;
        }

        public override void EnterState()
        {
            rb.velocity = Vector3.zero;
            Debug.Log("Entered Idle State");
        }

        public override void UpdateState()
        {
            // Handle idle-specific logic
        }

        public override void ExitState() => Debug.Log("Exited Idle State");
    }
}
