using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3();
        if (speed == 0)
        {
            speed = 1;
        }
    }

    // Moves the object based on the given velocity, and it points in that given direction
    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
    }
}
