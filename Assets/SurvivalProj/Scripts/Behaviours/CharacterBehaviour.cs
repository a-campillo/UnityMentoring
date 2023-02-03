namespace SurvivalProj.Behaviours
{
    using UnityEngine;

    public class CharacterBehaviour : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float moveSpeed = 10F;

        [SerializeField]
        private float runSpeed = 60F;

        [Header("Rotation")]
        [SerializeField]
        private float rotationSpeed = 20F;

        [SerializeField]
        private float mouseRotationDeadZone = 10F;

        private Character character;
        private Weapon weapon;

        private float yVal = 0F;

        private bool isRunning = false;

        private new Rigidbody rigidbody;

        private Ray ray;
        private RaycastHit hit;

        private Vector3 screenCenter;

        public Character Character { get { return character; } }

        // Start is called before the first frame update
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;

            character = new Character("Hero", 10);
            weapon = new Weapon("PeyeSword");

            screenCenter = new Vector3(Screen.width / 2F, Screen.height / 2F);

            this.rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            //ProcessMovement();
            ProcessRotation();
        }

        private void ProcessMovement()
        {
            yVal = Input.GetAxis("Vertical");

            if (yVal != 0F)
            {
                isRunning = Input.GetAxis("Fire2") > 0;

                if (isRunning)
                {
                    transform.Translate(Vector3.forward * runSpeed * yVal * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.forward * moveSpeed * yVal * Time.deltaTime);
                }
            }
        }

        private void FixedUpdate()
        {
            ProcessMovementWithPhysics();
        }

        private void ProcessMovementWithPhysics()
        {
            yVal = Input.GetAxis("Vertical");

            if (yVal != 0)
            {
                isRunning = Input.GetAxis("Fire2") > 0;
                rigidbody.MovePosition(transform.position + transform.forward * (isRunning ? runSpeed : moveSpeed) * yVal * Time.fixedDeltaTime);
            }
        }

        private void ProcessRotation()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point); // Look at the point
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            }
        }
    }
}