using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMove : BaseMovement
{
    public float jumpForce = 6.5f;
    public bool isGrounded;
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded) {
            Jump();
        }
        rigidbody.MovePosition(transform.position + movementVector * movementSpeed * Time.fixedDeltaTime);
    }

    private void Jump(){
        isGrounded = false;
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision other) {
        isGrounded = true;
    }
}
