using UnityEngine;

namespace Code.Scripts.Player
{

    public class BasicMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        [SerializeField]private Rigidbody rb;
        [SerializeField]private Transform body;
        [SerializeField] private Camera playerCamera;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            HandlePlayerMovement();
            HandlePlayerTurning();
        }
        private void HandlePlayerMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput,0f ,  verticalInput);
        
            rb.MovePosition((Vector3)transform.position + (direction * (moveSpeed * Time.deltaTime)));
        }
    
        private void HandlePlayerTurning()
        {
            bool success = GetMousePosition().success;
            Vector3 position = GetMousePosition().position;
            if (success)
            {
                Vector3 direction = position - transform.position;
                direction.y = 0;
                body.forward = direction;
            }
        }
    
        private (bool success, Vector3 position) GetMousePosition()
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
                return (success: true, position: hitInfo.point);
        
            else
                return (success: false, position: Vector3.zero);
        }

    }
}