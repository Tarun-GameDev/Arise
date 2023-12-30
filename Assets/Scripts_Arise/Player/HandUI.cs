using UnityEngine;
using UnityEngine.UI;

public class HandUI : MonoBehaviour
{
    public GameObject objectToFollow;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (objectToFollow != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectToFollow.transform.position);

            rectTransform.position = screenPosition;
        }
    }
}
