#nullable enable

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    [SerializeField] private OnGoalReach? _onGoalReach;
    
    /*****************
     * Unity methods *
     *****************/
    private void Start()
    {
        var colliderComp = GetComponent<Collider>();
        Assert.IsNotNull(colliderComp, "No collider!");
        Assert.IsTrue(colliderComp.isTrigger, "Collider is not a trigger!");
    }

    /*******************
     * private methods * 
     *******************/
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
    }
    
    /**********
     * Events *
     **********/
    public class OnGoalReach : UnityEvent 
    {}
}
