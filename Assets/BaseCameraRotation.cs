using UnityEngine;

public class BaseCameraRotation : MonoBehaviour
{
    [SerializeField]
    protected float senstivity = 4.0f;
    [SerializeField]
    protected float smooth = 10;
    [SerializeField]
    protected Transform character;
    protected float yRotation;
    protected float xRotation;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * senstivity;
        xRotation -= Input.GetAxis("Mouse Y") * senstivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    protected void Rotate(){
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * smooth);
        character.rotation = Quaternion.Lerp(character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * smooth);
    }
}
