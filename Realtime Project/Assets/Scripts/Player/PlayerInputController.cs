using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerInteract))]
public class PlayerInputController : MonoBehaviour
{
    PlayerAttack Attack;
    PlayerMovement Movement;
    PlayerInteract Interact;
    
    [Range(1f, 10f)]
    public float MouseSensitivity = 2;
    [Range(1,10f)]
    public static float CurrentSensitivity = 1;
    float AttackingSensitivity;

    // Start is called before the first frame update
    void Awake()
    {
        Attack = GetComponent<PlayerAttack>();
        Movement = GetComponent<PlayerMovement>();
        Interact = GetComponent<PlayerInteract>();
        UpdateSensitivity(MouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {

        if (MenuManager.ActiveMenu == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack.Attack();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Interact.Interact();
            }
        }

        

        // State Machine would be too much work right now.
        // It would have to be hierarchical 
        if (Attack.isAttacking)
        {
            CurrentSensitivity = AttackingSensitivity;
        }
        else
        {
            CurrentSensitivity = MouseSensitivity;
        }

        // Raw input. Otherwise Axis output is smoothed.
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Movement.Move(input);

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * CurrentSensitivity;
        Movement.Aim(mouseInput);
    }
    public void UpdateSensitivity(float newSensitivity)
    {
        MouseSensitivity = newSensitivity;
        CurrentSensitivity = MouseSensitivity;
        AttackingSensitivity = MouseSensitivity / 2;
    }
}
