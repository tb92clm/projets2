using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed= 3f;

    [SerializeField]
    private float SensiX = 3f;

    [SerializeField]
    private float SensiY = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //calculer la vitesse du mvment
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * yMov;

        Vector3 vitesse = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(vitesse);

        //Calcul de la rotation du joueur en un vector3
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * SensiX;

        motor.Rotate(rotation);

        //Calcul de la rotation de la caméra en un vector3
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * SensiY;

        motor.RotateCamera(cameraRotation);
    }


}
