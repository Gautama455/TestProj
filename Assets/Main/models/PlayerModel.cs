using UnityEngine;

namespace Game.Models
{

    public class PlayerModel
    {
        private Vector3 _position;
        private readonly float _speed;

        public Vector3 Position => _position;

        public PlayerModel(Vector3 startPosition, float speed)
        {
            _position = startPosition;
            _speed = speed;
        }
    }
}
