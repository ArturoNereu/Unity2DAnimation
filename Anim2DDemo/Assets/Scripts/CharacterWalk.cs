using UnityEngine;

public class CharacterWalk : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float movementSpeed = 10;

    private float initialXScale;

    private Rigidbody2D characterRigidbody;

	// Use this for initialization
	void Start ()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        initialXScale = transform.localScale.x;
    }

    void MoveLeft()
    {
        characterRigidbody.velocity = new Vector3(-movementSpeed, 0, 0);
    }

    void MoveRight()
    {
        characterRigidbody.velocity = new Vector3(movementSpeed, 0, 0);
    }

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else
        {
            characterRigidbody.velocity = Vector3.zero;
        }
        
        if(characterRigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(initialXScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-initialXScale, transform.localScale.y, transform.localScale.z);
        }

        animator.SetFloat("MovementSpeed", characterRigidbody.velocity.magnitude);
	}
}
