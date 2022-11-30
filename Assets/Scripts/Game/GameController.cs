#nullable enable

using System;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _finishText = null!; 
    [SerializeField] private GameObject _failText = null!; 
    [SerializeField] private GameObject _restartButton = null!; 
    
    /*****************
     * Unity methods *
     *****************/
    private void Start()
    {
        Assert.IsNotNull(_finishText, "Finish text is null!");
        Assert.IsNotNull(_failText, "Fail text is null!");
        Assert.IsNotNull(_restartButton, "Restart button is null!");
    }

    /******************
     * public methods *
     ******************/
    public void ShowFinishScreen()
    {
        _finishText.SetActive(true);
        _restartButton.SetActive(true);
    }
    
    public void ShowFailScreen()
    {
        _failText.SetActive(true);
        _restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        _finishText.SetActive(false);
        _failText.SetActive(false);
        _restartButton.SetActive(false);
    }
}