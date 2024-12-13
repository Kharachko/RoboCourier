using UnityEngine;

namespace Player
{
    public class JumpingState : BaseState<PlayerState>
    {
        private Rigidbody rb;
        private float jumpForce = 10f;

        public JumpingState(Rigidbody rigidbody) : base(PlayerState.Jumping)
        {
            rb = rigidbody;
        }

        public override void EnterState()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Entered Jumping State");
        }

        public override void UpdateState()
        {
            // Handle jumping-specific logic
        }

        public override void ExitState() => Debug.Log("Exited Jumping State");
    }
}
