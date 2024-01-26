using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PlayerController playerController;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    private void Start()
    {
        
    }
    public PlayerController PlayerController { get { return playerController; } }
}
