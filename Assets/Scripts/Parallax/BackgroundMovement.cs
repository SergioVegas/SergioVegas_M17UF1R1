using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float startPosition;
    private float length = 29.0659f;
    public GameObject camera;
    public float parallaxEffect;

    private void Start()
    {
        startPosition = transform.position.x;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxEffect; // 0 = seguirá a la camara || 1= no se mueve
        float movement = camera.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if (movement > startPosition + length)
        {
            startPosition += length;
        }
        else if(movement < startPosition - length)
        { startPosition -= length; }
    }
}
