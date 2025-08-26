using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel _model;
        [SerializeField] private PlayerView _view;

        private float _horizontalInput;
        private float _verticalInput;
        private bool _jumpInput;


        void Awake()
        {
            _model = new PlayerModel();
            _view = GetComponent<PlayerView>();
            if (_view == null)
            {
                Debug.LogError("PlayerView component is missing!");
                enabled = false;
            }
        }

        void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            _jumpInput = Input.GetButtonDown("Jump");
        }

        void FixedUpdate()
        {
            Vector3 direction = new Vector3(_verticalInput, 0f, _horizontalInput);
            direction = Vector3.ClampMagnitude(direction, 1f);

            Vector3 velocity = direction * _model.Speed;
            velocity.y = _view._rb.linearVelocity.y;
            _view._rb.linearVelocity = velocity;

            CheckGrounded();

            if (_jumpInput && _model.IsGrounded)
            {
                _view._rb.AddForce(Vector3.up * _model.JumpForce, ForceMode.VelocityChange);
                _model.IsGrounded = false;
            }

            _view.UpdateAnimation(direction.magnitude, !_model.IsGrounded);

            _view.RotateTowards(direction, _model.RotationSpeed);
        }

        private void CheckGrounded()
        {
            float rayLength = 0.2f;
            Ray ray = new Ray(transform.position + Vector3.up * 0.1f, Vector3.down);
            _model.IsGrounded = Physics.Raycast(ray, rayLength);
        }
    }
}
