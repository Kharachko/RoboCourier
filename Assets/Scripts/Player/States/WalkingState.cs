using UnityEngine;

namespace Player
{
    public class WalkingState : BaseState<PlayerState>
    {
        private Rigidbody rb;
        private float moveSpeed = 5f;

        public WalkingState(Rigidbody rigidbody) : base(PlayerState.Walking)
        {
            rb = rigidbody;
        }

        public override void EnterState() => Debug.Log("Entered Walking State");

        public override void UpdateState()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

            if (direction.magnitude >= 0.1f)
            {
                rb.velocity = direction * moveSpeed;
            }
        }

        public override void ExitState() => Debug.Log("Exited Walking State");
    }
}
