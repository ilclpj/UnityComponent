using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public JoyStick joyStick;
    public RectTransform player;
    public float playerSpeed;


    // Update is called once per frame
    protected void Update()
    {
        if (!joyStick.stickRunning) return;

        player.anchoredPosition += joyStick.stickDirection * playerSpeed;
    }
}