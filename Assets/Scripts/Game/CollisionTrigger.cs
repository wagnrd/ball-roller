#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private List<OnEnter> _onEnter = new List<OnEnter>();
    
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
        foreach (var listener in _onEnter)
            listener?.Invoke();
    }
    
    /**********
     * Events *
     **********/
    [Serializable]
    public class OnEnter : UnityEvent 
    {}
}
