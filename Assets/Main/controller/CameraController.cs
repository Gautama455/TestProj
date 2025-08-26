using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("������ �� Transform �������� ���������, �� ������� ����� ��������� ������.")]
    [SerializeField] private Transform _player;

    [Tooltip("�������� ������ ������������ ������� ������.")]
    [SerializeField] private Vector3 _offset;

    [Tooltip("��������, � ������� ������ ����� ������ ��������� � ������� �������.")]
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
