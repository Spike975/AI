using UnityEngine;

public class Avoid : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity;
    public float radius;
    public Ray front;
    public Ray pos;
    public Ray neg;
    // Update is called once per frame
    void Update()
    {
        Vector3 v = target.transform.position - transform.position;
        front.direction = gameObject.GetComponent<AIScript>().velocity;
        front.origin = transform.position; 
        float distance = (transform.position - target.transform.position).sqrMagnitude;
        if (distance < radius)
        {
            v = (target.transform.position - transform.position).normalized;
            v *= Mathf.Min(distance / radius, maxVelocity);
            gameObject.GetComponent<AIScript>().velocity -= v * Time.deltaTime;
        }
    }
}
