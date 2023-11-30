using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] GameObject storeCanvas;
    public void Exit()
    {
        Time.timeScale = 1f;
        storeCanvas.SetActive(false);
    }
}
