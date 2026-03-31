using System;
using UnityEngine;

public class BallReaction : MonoBehaviour
{
    [SerializeField] private Variables variables;
    
    private Rigidbody2D _rb;
    private float _radius;
    private float _maxTargetY;
    private float _minTargetY;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
            Debug.LogError($"Missing rigidbody on target ball {gameObject.name}");
        _radius = variables.ballScaler / 2;
        _maxTargetY = variables.barPosition.position.y + (_radius + variables.barScale.localScale.y / 2);
        _minTargetY = variables.barPosition.position.y - (_radius + variables.barScale.localScale.y / 2);
    }

    private void Update()
    {
        if(gameObject.transform.position.y < -5)
            FailedClick();
    }

    public void Clicked()
    {
        if (!InRange())
        {
            FailedClick();
            return;
        }
        GameManager.Instance.AddScore(gameObject, _rb);
    }

    public bool UpdateTargetArea(float barYScale, float barYPosition)
    {
        if (Camera.main != null && barYPosition < Camera.main.ScreenToWorldPoint(Vector3.zero).y) return false;
        if (barYScale <= 0) return false;
        
        _maxTargetY = barYPosition + (_radius + barYScale / 2);
        _minTargetY = barYPosition - (_radius + barYScale / 2);
        
        return true;
    }

    public bool InRange()
    {
        return(_minTargetY <= _rb.position.y && _rb.position.y <= _maxTargetY);
    }

    private void FailedClick()
    {
        GameManager.Instance.ResetBall(gameObject, _rb);
    }
}
