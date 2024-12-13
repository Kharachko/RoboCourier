using System;
using UnityEngine;

namespace Player
{
    public enum PlayerState
    {
        Idle,
        Walking,
        Jumping
    }

    public class PlayerStateMachine : StateMachine<PlayerState>
    {
        private bool isWalking;
        private bool isJumping;

        protected override PlayerState GetNextState()
        {
            if (isJumping) return PlayerState.Jumping;
            if (isWalking) return PlayerState.Walking;

            return PlayerState.Idle;
        }

        public void SetWalking(bool walking) => isWalking = walking;
        public void SetJumping(bool jumping) => isJumping = jumping;
    }
}
