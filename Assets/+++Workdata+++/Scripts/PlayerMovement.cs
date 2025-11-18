using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float moveSpeed = 5f;
  [SerializeField] Rigidbody2D rb;
  private Vector2 moveInput;
  [SerializeField] private MochiNPC Mochi;

  [SerializeField] private GameObject DialogBox;
  public bool canMove;

  void Start()
  {
    canMove = true;
    if (rb == null)
    {
      rb = GetComponent<Rigidbody2D>();
    }
  }

  private void Update()
  {
    if (canMove)
    {
      rb.linearVelocity = moveInput * moveSpeed;
    }
  }


  public void Move(InputAction.CallbackContext context)
  {
    moveInput = context.ReadValue<Vector2>();
  }


  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("MochiTrigger"))
    {
      Mochi.canBeInteracted = true;
    }
    
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.CompareTag("MochiTrigger"))
    {
      Mochi.canBeInteracted = false;

    }
  }


  public void InitiateMochiDialogBox()
  {
    if (Mochi.canBeInteracted == true && DialogBox.activeSelf)
    {
      canMove = false;
      rb.linearVelocity = Vector2.zero;
      DialogBox.SetActive(true);
    }
  }


  public void EndMochiDialogBox()
  {
    if (DialogBox.activeSelf == true)
    {
      canMove = true;
      DialogBox.SetActive(false);
    }
  }
  
  

}
