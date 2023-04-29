using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSettins;
using UnityEngine.InputSystem;
using System;

public class InputManager : Singleton<InputManager>
{
    public InputSettins.InputSettings playerInput;
    public PlayerMove miner, battler;
    public event Action OnJump;


    private new void Awake()
    {
        base.Awake();
        playerInput = new InputSettins.InputSettings();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Jump.started += OnJumpInput;
    }
    private void OnDisable()
    {
        playerInput.Player.Jump.started -= OnJumpInput;
        playerInput.Disable();
    }
    private void Update()
    {
        miner.controlDir = playerInput.Player.MinerMove.ReadValue<float>();
        battler.controlDir = playerInput.Player.BattlerMove.ReadValue<float>();
    }
    public void OnJumpInput(InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }
}
[Serializable]
public class PlayerMove
{
    public float controlDir;
}