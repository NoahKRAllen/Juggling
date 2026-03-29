using UnityEngine;

public class BallReaction : MonoBehaviour
{
    private Rigidbody2D _rb;
    Transform _targetBarPosition;
    private float _radius;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError($"Missing rigidbody on target ball {gameObject.name}");
        _radius = Variables.Instance.ballRadius;
        _targetBarPosition = Variables.Instance.targetBar.transform;
    }

    public void Clicked()
    {
        if (!InRange())
        {
            FailedClick();
            return;
        }
        var vector3 = gameObject.transform.position;
        vector3.y += 12;
        gameObject.transform.position = vector3;
        _rb.linearVelocity = Vector3.zero;
    }

    public bool InRange()
    {
        return Mathf.Abs(gameObject.transform.position.y - _targetBarPosition.position.y) <= _radius + _targetBarPosition.localScale.y / 2;
    }

    private void FailedClick()
    {
        print("Clicked too soon");
    }
}
