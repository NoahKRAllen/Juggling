using UnityEngine;
using UnityEngine.Serialization;

public class BallReaction : MonoBehaviour
{
    [SerializeField]private Transform targetBarPosition;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D _rb;
    private float _radius;
    private float _maxTargetY;
    private float _minTargetY;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError($"Missing rigidbody on target ball {gameObject.name}");
        _radius = gameObject.transform.localScale.y / 2; ;
        _maxTargetY = targetBarPosition.position.y + (_radius + targetBarPosition.localScale.y / 2);
        _minTargetY = targetBarPosition.position.y - (_radius + targetBarPosition.localScale.y / 2);
    }

    public void Clicked()
    {
        if (!InRange())
        {
            FailedClick();
            return;
        }
        gameObject.transform.position = new Vector3(0, jumpHeight, 0);
        _rb.linearVelocity = Vector3.zero;
    }

    public bool InRange()
    {
        return(_minTargetY <= _rb.position.y && _rb.position.y <= _maxTargetY);
    }

    private void FailedClick()
    {
        print($"Clicked too soon on {gameObject.name}");
    }
}
