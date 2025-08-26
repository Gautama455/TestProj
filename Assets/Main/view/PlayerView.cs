using UnityEngine;

namespace Game.View
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] public Rigidbody _rb;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }

        public void UpdateAnimation(float speed, bool isJumping)
        {
            if (_animator != null)
            {
                _animator.SetFloat("MovementSpeed", speed);
                _animator.SetBool("IsJumping", isJumping);
            }
        }

        public void RotateTowards(Vector3 direction, float rotationSpeed)
        {
            if (direction.sqrMagnitude > float.Epsilon)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
