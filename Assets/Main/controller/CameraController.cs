using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Ссылка на Transform игрового персонажа, за которым будет следовать камера.")]
    [SerializeField] private Transform _player;

    [Tooltip("Смещение камеры относительно позиции игрока.")]
    [SerializeField] private Vector3 _offset;

    [Tooltip("Скорость, с которой камера будет плавно двигаться к целевой позиции.")]
    [SerializeField] private float positionSpeed = 5f;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            _player.position.x + _offset.x,
            _player.position.y + _offset.y,
            _offset.z                      
        );

        transform.position = Vector3.Lerp(transform.position, targetPosition, positionSpeed * Time.deltaTime);
    }
}
