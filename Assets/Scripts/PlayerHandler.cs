using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 movement;
    private Rigidbody2D _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //movement = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 direction = new Vector2(movement.ReadValue<Vector2>().x, movement.ReadValue<Vector2>().y);
        //transform.position = transform.right * direction * speed;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = movement * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());
        LookAt(mousePos);
    }

    private void LookAt(Vector3 target)
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position, target);

        transform.eulerAngles = new Vector3(0, 0, lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
