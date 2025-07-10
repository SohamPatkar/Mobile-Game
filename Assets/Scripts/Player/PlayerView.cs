using Cinemachine;
using UnityEngine;

namespace MobileController.Player
{
    public class PlayerView : MonoBehaviour
    {
        #region  private fields

        [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
        [SerializeField] private Camera cameraMain;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject playerModel;
        [SerializeField] private PlayerScriptableObject playerSO;

        private Rigidbody characterRb;
        private PlayerController playerController;
        private PlayerControls playerControls;

        #endregion

        void Awake()
        {
            characterRb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            SetController();
            playerControls = playerController.GetPlayerInput();
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerController.GetPlayerInput().Disable();
        }

        void Update()
        {
            if (playerController != null)
            {
                playerController.Movement();
                playerController.CameraMovement();
                playerController.Jump();
                playerController.Attack();
            }

            if (playerController.GetPlayerInput().Player.Dash.triggered)
            {
                StartCoroutine(playerController.Dash());
            }
        }



        public CinemachineFreeLook GetCinemachineFreeLook()
        {
            return cinemachineFreeLook;
        }

        public Camera GetCamera()
        {
            return cameraMain;
        }

        public GameObject GetPlayerModel()
        {
            return playerModel;
        }

        public Animator GetCharacterAnimator()
        {
            return animator;
        }

        public Rigidbody ReturnCharacterController()
        {
            return characterRb;
        }

        public void SetController()
        {
            playerController = new PlayerController(this, playerSO);
        }
    }
}


