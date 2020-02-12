using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    private Vector3 force;

    // Update is called once per frame
    void Update()
    {
        Vector3 v = (target.transform.position - transform.position).normalized;
        force = v - gameObject.GetComponent<AIScript>().velocity;
        gameObject.GetComponent<AIScript>().velocity += force * Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, force);
    }
}
