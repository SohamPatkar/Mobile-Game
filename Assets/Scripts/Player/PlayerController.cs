using System.Collections;
using Cinemachine;
using UnityEngine;

namespace MobileController.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerControls playerInput;
        private CinemachineFreeLook playerCam;
        private Animator playerAnimator;
        private Rigidbody playerRigidBody;
        private PlayerScriptableObject playerSo;
        private Camera cameraMain;
        private int playerHealth;
        private bool isDashing = false;
        private Vector2 moveAction;

        public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
        {
            playerSo = playerSO;
            this.playerView = playerView;

            Initialize();
        }

        private void Initialize()
        {
            playerHealth = playerSo.PlayerHealth;

            playerRigidBody = playerView.ReturnCharacterController();
            playerCam = playerView.GetCinemachineFreeLook();
            cameraMain = playerView.GetCamera();
            playerAnimator = playerView.GetCharacterAnimator();

            playerInput = new PlayerControls();
        }

        public void CameraMovement()
        {
            Vector2 lookAction = playerInput.Player.Look.ReadValue<Vector2>();

            playerCam.m_XAxis.Value += lookAction.x * Time.deltaTime * 200f;
            playerCam.m_YAxis.Value += lookAction.y * Time.deltaTime;

            if (playerCam.m_YAxis.Value < 0.5f)
            {
                playerCam.m_YAxis.Value = 0.5f;
            }
        }

        public void Movement()
        {
            if (isDashing)
            {
                playerRigidBody.velocity = playerView.gameObject.transform.forward * playerSo.DashSpeed;
                return;
            }

            moveAction = playerInput.Player.Move.ReadValue<Vector2>();

            Vector3 moveDir = playerView.transform.forward * moveAction.y + playerView.transform.right * moveAction.x;

            moveDir.y = 0f;

            moveDir = moveDir.normalized;

            Vector3 velocity = moveDir * playerSo.PlayerSpeed;

            velocity.y = playerRigidBody.velocity.y;

            playerRigidBody.velocity = velocity;

            if (moveDir.magnitude > 0.1f)
            {
                Vector3 camForward = cameraMain.transform.forward;
                camForward.y = 0f;
                camForward.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(camForward);

                playerView.transform.rotation = Quaternion.Slerp(playerView.transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
            }

            float speed = moveDir.magnitude;

            playerAnimator.SetFloat("Speed", speed);
        }

        public void Jump()
        {
            if (playerInput.Player.Jump.triggered)
            {
                playerRigidBody.velocity = Vector3.up * 5f;
                playerAnimator.SetTrigger("Dash");
            }
        }

        public void TakeDamage()
        {
            playerHealth -= (int)playerSo.PlayerDamage;

            if (playerHealth < 0)
            {
                playerHealth = 0;
            }
        }

        public void Attack()
        {
            if (playerInput.Player.Attack.triggered)
            {
                playerAnimator.SetTrigger("Attack");
            }
        }

        public IEnumerator Dash()
        {
            if (isDashing)
            {
                yield break;
            }

            isDashing = true;
            playerAnimator.SetTrigger("Dash");
            yield return new WaitForSeconds(0.5f);
            isDashing = false;
        }

        public PlayerControls GetPlayerInput()
        {
            return playerInput;
        }
    }
}


