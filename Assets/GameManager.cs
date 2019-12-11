using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    private void Start()
    {
        PlayerScore = 0;
    }
    private void Update()
    {
        Debug.Log(PlayerScore);
    }
}
