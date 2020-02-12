using UnityEngine;

public class Flee : MonoBehaviour
{
    public GameObject target;
    public float maxVelocity;
    public float radius;
    private Vector3 force;

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - target.transform.position).sqrMagnitude;
        if (distance <= radius)
        {
            Vector3 v = ((target.transform.position - transform.position) * maxVelocity).normalized;
            force = v + gameObject.GetComponent<AIScript>().velocity;
            gameObject.GetComponent<AIScript>().velocity -= force * Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(target.transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, force);
    }
}
