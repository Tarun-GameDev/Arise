using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 touchStartPos;
    [SerializeField] float speedMultiplier = 1f;
    private bool isTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isTouching = true;
                    break;

                case TouchPhase.Moved:
                    if (isTouching)
                    {

                        rb.MovePosition(new Vector3((touch.deltaPosition.x * speedMultiplier * Time.deltaTime) + rb.position.x, (touch.deltaPosition.y * speedMultiplier * Time.deltaTime) + rb.position.y,0f));
                            /** speedMultiplier * Time.deltaTime, 0f));

                        Vector3 touchCurrentPos = touch.position;
                        Vector3 touchDelta = touchCurrentPos - touchStartPos;

                        // Calculate the position change and set it as the object's position
                        rb.position += new Vector3(touchDelta.x, touchDelta.y,0f);

                        touchStartPos = touchCurrentPos; // Update the starting touch position*/
                    }
                    break;

                case TouchPhase.Ended:
                    isTouching = false;
                    break;
            }
        }
    }
}
