using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorController : MonoBehaviour
{
    #region Variables Serializadas
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty ataqueBasico1;
    [SerializeField] private InputActionProperty ataqueBasico2;
    [SerializeField] private float velocidad = 5f;
    #endregion

    #region Variables
    private Vector2 movimiento;
    private Rigidbody2D rb;
    private Animator animator; // Referencia al Animator
    private SpriteRenderer spriteRenderer; // Referencia al renderer, para voltear el sprite
    #endregion

    private void Awake()
    {
        // Obtenemos el Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        ataqueBasico1.action.Enable();
        ataqueBasico2.action.Enable();

        ataqueBasico1.action.performed += AtacarBasico1;
        ataqueBasico2.action.performed += AtacarBasico2;
    }

    private void OnDisable()
    {
        ataqueBasico1.action.performed -= AtacarBasico1;
        ataqueBasico2.action.performed -= AtacarBasico2;
        moveAction.action.Disable();
        ataqueBasico1.action.Disable();
        ataqueBasico2.action.Disable();

        
    }

    private void Update()
    {
        // Lee el Vector2 de la acción y limita su longitud a 1 (sin forzarla a 1 como normalized).
        movimiento = moveAction.action.ReadValue<Vector2>();

        // magnitude = longitud del vector: 0 parado, hasta 1 a máxima velocidad.
        // Se envía al parámetro Float "Velocidad" del Animator.
        movimiento = movimiento.normalized;      

        andar(movimiento);
    }

    private void FixedUpdate()
    {
        // Aplicamos el movimiento mediante físicas
        rb.MovePosition(
            rb.position + movimiento * velocidad * Time.fixedDeltaTime
        );
    }

    private void andar(Vector2 move)
    {
        if(move.x > 0.01f)
        {
            spriteRenderer.flipX = false;
        }else if(move.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        animator.SetFloat("andar",move.magnitude);
    }

    private void AtacarBasico1(InputAction.CallbackContext context)
    {
        Debug.Log("Ataque1 disparado");
        animator.SetTrigger("ataque1");
    }

    private void AtacarBasico2(InputAction.CallbackContext context)
    {
        animator.SetTrigger("ataque2");
    }
}
