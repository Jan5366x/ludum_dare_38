﻿using System.Collections;
using Assets.scripts;
using logic.character;
using UnityEngine;

namespace movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float BaseSpeed = 2f;
        public float SpeedFactorWalk = 0.5f;
        public float SpeedFactorRun = 1f;
        public bool SprintOverride;

        private Animator _animator;
        private PlayerLogic _player;

        private float staminaTimer = 0f;

        // Use this for initialization
        void Start()
        {
            _animator = GetComponent<Animator>();
            _player = GetComponentInParent<PlayerLogic>();
        }

        

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_player.HitPoints.Dead)
            {
                StopAllCoroutines();
                return;
            }
            var movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized
                                 * Time.deltaTime * BaseSpeed;

            float speedFactor;

            if (Input.GetButton("Sprint") && _player.Stamina.CurrentValue > _player.Stamina.MinValue || SprintOverride)
            {
                _player.Stamina.CurrentValue -= GameProperties.PLAYER_STAMINA_DEC_RATE_FRAME;
                speedFactor = SpeedFactorRun;

                staminaTimer = GameProperties.PLAYER_STAMINA_RECOVERY_RATE;
            } else {
                if (!Input.GetButton("Sprint")) {
                    if (staminaTimer <= 0)
                    {
                        _player.Stamina.CurrentValue += GameProperties.PLAYER_STAMINA_RECOVERY;
                        staminaTimer = GameProperties.PLAYER_STAMINA_RECOVERY_RATE;
                    }

                    staminaTimer -= Time.deltaTime;
                }

                // handle walk speed factor
                speedFactor = SpeedFactorWalk;
            }

            _animator.SetFloat("velocityX", movementVector.normalized.x);
            _animator.SetFloat("velocityY", movementVector.normalized.y);
            _animator.SetFloat("speed", movementVector.normalized.magnitude * speedFactor);

            transform.Translate(movementVector * speedFactor);
        }
    }
}

/**
* unused Dev code
*/
//var direction = -1;
//            if (movementVector.y > 0 && movementVector.x < movementVector.y)
//            {
//                direction = 2;
//            }
//            else if (movementVector.y < 0 && movementVector.x > movementVector.y)
//            {
//                direction = 0;
//            }
//            else if (movementVector.x > 0)
//            {
//                direction = 1;
//            }
//            else if (movementVector.x < 0)
//            {
//                direction = 3;
//            }
//
//            if (direction != -1)
//            {
//                _animator.SetInteger("direction", direction);
//            }