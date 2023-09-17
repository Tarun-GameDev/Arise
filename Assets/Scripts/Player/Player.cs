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

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * speedMultiplier);
            }
        }
    }
}
