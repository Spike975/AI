using UnityEngine;

public class AIScript : MonoBehaviour
{
    public  Vector3 velocity;
    public float speed;
    public float maxVelocity;

    private void Start()
    {
        if(maxVelocity == 0)
        {
            maxVelocity = 1;
        }
    }

    private void Update()
    {
        //velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);
        //velocity.z = Mathf.Clamp(velocity.z, -maxVelocity, maxVelocity);
        transform.position += velocity * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, velocity);
    }
}