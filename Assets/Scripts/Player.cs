using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Unity.Mathematics;

public static class Stats
{
    public static int carryLimit=PlayerPrefs.GetInt("CarryLimit",100);
    public static int hitPoint=PlayerPrefs.GetInt("HitPoint",1);
}
public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [Range(0,10)]
    public float moveSpeed=1;
    [Range(10,50)]
    public float rotateSpeed;
    private Vector3 _moveDir;
    private Quaternion _lookRot;
    private Animator _animator;
    private OreCollector _oreCollector;
    private float hitDelay;
    private void Start()
    {
        GetLocalComponents();
        InputManager.moveInput += Move;
        InputManager.moveInput += ControlAnimations;
        FloatingJoystick.onMoveStop += ControlAnimations;
    }

    void GetLocalComponents()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _oreCollector = GetComponent<OreCollector>();
    }

    void Move(Vector2 direction)
    {
        _moveDir = Vector3.right * direction.x + Vector3.forward * direction.y;
        _controller.Move(_moveDir*moveSpeed*Time.deltaTime);
        _lookRot = Quaternion.LookRotation(_moveDir.normalized, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation,_lookRot,Time.deltaTime*rotateSpeed);
    }

    void ControlAnimations(Vector2 direction)
    {
        _animator.SetFloat("Speed",direction.sqrMagnitude);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out Ore ore))
        {
            if(hitDelay<=0){OreController.instance.BreakOre(ore);
                hitDelay = 0.25f;
                _animator.SetTrigger("Hit");
            }
            else
            {
                hitDelay -= Time.deltaTime;
            }
        }
    }
}
