#nullable enable

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Board : MonoBehaviour
{
    [Header("Events")]
    public OnFail? _onFinish;
    public OnFail? _onFail;
    
    [SerializeField] private float _tiltSpeed;
    [SerializeField] private float _maxTiltDegrees;
    
    private Vector2 _lastMousePosition = Vector2.negativeInfinity;
    private Vector3 _boardRotation;
    
    /******************
     * public methods *
     ******************/
    public Vector3 Rotation => _boardRotation;

    public void OnMousePositionChange(InputAction.CallbackContext context)
    {
        var mousePosition = context.ReadValue<Vector2>();

        if (_lastMousePosition == Vector2.negativeInfinity)
            _lastMousePosition = mousePosition;

        var xDelta = mousePosition.x - _lastMousePosition.x;
        var yDelta = mousePosition.y - _lastMousePosition.y;

        var xAngleDelta = -yDelta * _tiltSpeed * Time.deltaTime;
        var zAngleDelta = xDelta * _tiltSpeed * Time.deltaTime;

        _boardRotation.x = Mathf.Clamp(_boardRotation.x + xAngleDelta, -_maxTiltDegrees, _maxTiltDegrees);
        _boardRotation.z = Mathf.Clamp(_boardRotation.z + zAngleDelta, -_maxTiltDegrees, _maxTiltDegrees);

        transform.localRotation = Quaternion.Euler(_boardRotation);

        _lastMousePosition = mousePosition;
    }

    public void TriggerFinish()
    {
        _onFinish?.Invoke();
    }

    public void TriggerFail()
    {
        _onFail?.Invoke();
    }
    
    /**********
     * Events * 
     **********/
    [Serializable]
    public class OnFinish : UnityEvent
    {}
    
    [Serializable]
    public class OnFail : UnityEvent
    {}
}
