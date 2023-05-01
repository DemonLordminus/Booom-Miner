using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSettins;
using UnityEngine.InputSystem;
using System;

public class InputManager : Singleton<InputManager>
{
    public InputSettins.InputSettings playerInput;
    public PlayerMove miner;
    public PlayerControl battler;
    public event Action OnJump;
    public event Action OnHook;
    public event Action OnSteam;

    private new void Awake()
    {
        base.Awake();
        playerInput = new InputSettins.InputSettings();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Jump.started += OnJumpInput;
        playerInput.Player.UseHook.started += OnHookInput;
        playerInput.Player.UseSteam.started += OnSteamInput;
    }
    private void OnDisable()
    {
        playerInput.Player.UseSteam.started -= OnSteamInput;
        playerInput.Player.UseHook.started -= OnHookInput;
        playerInput.Player.Jump.started -= OnJumpInput;
        playerInput.Disable();
    }
    private void Update()
    {
        miner.controlDir = playerInput.Player.MinerMove.ReadValue<float>();
        battler.controlDir = playerInput.Player.BattlerMove.ReadValue<Vector2>();
    }
    public void OnJumpInput(InputAction.CallbackContext obj)
    {
        OnJump?.Invoke();
    }
    public void OnHookInput(InputAction.CallbackContext obj)
    {
        OnHook?.Invoke();
    }
    public void OnSteamInput(InputAction.CallbackContext obj)
    {
        OnSteam?.Invoke();
    }
    
}
[Serializable]
public class PlayerMove
{
    public float controlDir;
}
[Serializable]
public class PlayerControl
{
    public Vector2 controlDir;
}