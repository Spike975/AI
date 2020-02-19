using UnityEngine;

public class Arrive : MonoBehaviour
{
    public GameObject target;
    public float radius;
    public float maxVelocity;
    private Vector3 v;

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - target.transform.position).sqrMagnitude;
        if (distance < radius)
        {
            v = (target.transform.position - transform.position).normalized;
            v *= Mathf.Min(distance / radius, maxVelocity);
            gameObject.GetComponent<AIScript>().velocity += v * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(target.transform.position, radius);
        Gizmos.DrawRay(transform.position, v.normalized);
    }
}
