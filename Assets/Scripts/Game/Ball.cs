#nullable enable

using UnityEngine;
using UnityEngine.Assertions;

public class Ball : MonoBehaviour
{
    [SerializeField] private Board _board = null!;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _gravity;

    private Rigidbody _rigidbody = null!;
    
    /*****************
     * Unity methods *
     *****************/
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        Assert.IsNotNull(_board, "Board is null!");
        Assert.IsNotNull(_rigidbody, "Rigidbody is null!");
    }

    private void FixedUpdate()
    {
        var xForce = -_board.Rotation.z * _acceleration * Time.deltaTime;
        var zForce = _board.Rotation.x * _acceleration * Time.deltaTime;
        var yForce = -_gravity * Time.deltaTime;
        
        _rigidbody.AddForce(xForce, yForce, zForce);
    } 
    
    /*******************
     * private methods * 
     *******************/
}
