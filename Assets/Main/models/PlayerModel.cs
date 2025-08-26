using UnityEngine;

namespace Game.Model
{
    public class PlayerModel
    {
        public float Speed = 2f;
        public float RotationSpeed = 10f;
        public float JumpForce = 8f;

        public bool IsGrounded { get; set; }
    }
}
