using UnityEngine;

public class Evade : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity;
    public float speed;
    public Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        Vector3 v = (((target.transform.position + target.GetComponent<AIScript>().velocity) - transform.position) * maxVelocity).normalized;
        Vector3 force = v + gameObject.GetComponent<AIScript>().velocity;
        velocity -= force * Time.deltaTime;
        gameObject.GetComponent<AIScript>().velocity += velocity * Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, velocity);
    }
}
