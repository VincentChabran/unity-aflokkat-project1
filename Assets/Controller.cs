using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    public float vitesse = 4f;
    public bool monte;

    public void JumpKeyPressed(InputAction.CallbackContext context)
    {
        // Si la touche est appuyée
        if (context.performed)
        {
            Debug.Log("Jump key pressed");

            monte = true;
        }
        // Si la touche est relâchée
        else if (context.canceled)
        {
            Debug.Log("Jump key released");

            monte = false;
        }
    }


    private void Update()
    {
        if (monte && transform.position.y < 6f)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * vitesse;
        }
        else if (!monte && transform.position.y > -4f)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * vitesse;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Character hit an obstacle");

        SceneManager.LoadScene(0);
    }
}
