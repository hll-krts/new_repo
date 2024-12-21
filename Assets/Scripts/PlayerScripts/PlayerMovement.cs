using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public bool _CanDodge = true;
    public float _dodgeCD, _dodgeStr;
    private float _nextDodge;
    private Rigidbody _rbody;
    private PlayerInput playerInput;
    private PlayerInputActionsCustom actionsCustom;
    Vector2 inputVector;
    public float _hitLife, _respawnLives;
    public float _moveSpd;
    private DetachChildren detachChildren;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        _nextDodge = 0;
        _rbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        detachChildren = GetComponent<DetachChildren>();

        actionsCustom = new PlayerInputActionsCustom();
        actionsCustom.DefaultControls.Enable();
    }

    private void Update()
    {
        if (Time.time > _nextDodge & !_CanDodge)
        {
            _CanDodge = true;
        }

        _rbody.velocity = Vector3.ClampMagnitude(_rbody.velocity, 3f);

        if (detachChildren.isDead)
            Time.timeScale = 0f;
    }

    private void FixedUpdate()
    {
        inputVector = actionsCustom.DefaultControls.Vector2_Move.ReadValue<Vector2>();

        Move();
    }
    public void Move()
    {
        float speed = _moveSpd;
        _rbody.AddForce(this.transform.right * inputVector.x * speed, ForceMode.Force);
        _rbody.AddForce(this.transform.forward * inputVector.y * speed, ForceMode.Force);
    }

    /*public void ADodge(InputAction.CallbackContext context)
    {
        float dodgeStr = _dodgeStr;

        if (context.performed && _CanDodge)
        {
            _rbody.AddForce(transform.right * inputVector.x * dodgeStr, ForceMode.Impulse);
            _rbody.AddForce(transform.forward * inputVector.y * dodgeStr, ForceMode.Impulse);

            _CanDodge = false;
            _nextDodge = Time.time + _dodgeCD;
        }

    }*/

    public void ASpecialMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(detachChildren.childObject.GetComponent<BossScript_Kratos>() != null)
            {
                detachChildren.childObject.GetComponent<BossScript_Kratos>().Special();
            }
            else if(detachChildren.childObject.GetComponent<BossScript_Soldier>() != null)
            {
                detachChildren.childObject.GetComponent<BossScript_Soldier>().Special();
            }
            else if(detachChildren.childObject.GetComponent<BossScript_Rambo>() != null)
            {
                //PASSIVE ABILITY - detachChildren.childObject.GetComponent<BossScript_Rambo>().Special();
            }
        }
    }

    public void MinionHit(float damage)
    {
        _hitLife-= damage;
        if (_hitLife <= 0)
        {
            detachChildren.isDead = true;
            gameManager.GameOver();
        }
    }
    public void BossHit(float damage)
    {
        _hitLife-=damage;
        if (_hitLife <= 0)
        {
            detachChildren.isGhost = true;
            detachChildren.YeetTheChild();
            gameManager.BossPickCanvasA();
            _respawnLives--;
            if (_respawnLives <= 0)
            {
                detachChildren.isDead = true;
            }
        }
    }
}