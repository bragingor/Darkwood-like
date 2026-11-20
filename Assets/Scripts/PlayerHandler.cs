using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float pickUpradius;
    [SerializeField] private LayerMask weaponLayer;

    private Vector2 movement;
    private Vector2 mousePos;

    private Rigidbody2D _rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAt(mousePos);

    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = transform.rotation * new Vector2(-movement.y, movement.x) * speed * Time.fixedDeltaTime;
    }

    private void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }

    private void OnLook(InputValue inputValue)
    {
        mousePos = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());
    }

    private void OnInteract(InputValue inputValue)
    {
        var weapon = Physics2D.OverlapCircle(transform.position, pickUpradius, weaponLayer);
        if (weapon)
        {
            weapon.gameObject.transform.SetParent(transform, true);
            weapon.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            weapon.gameObject.layer = 0;
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickUpradius);
    }
}
