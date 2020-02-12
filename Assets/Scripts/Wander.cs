using UnityEngine;

public class Wander : MonoBehaviour
{
    public float maxVelocity;
    public float circleRaduis;
    public float distance;
    public float jitter;
    public float angle;
    public float extra;
    private Vector3 circleCenter;
    private Vector3 displacement;

    // Update is called once per frame
    void Update()
    {
        if(extra == 0)
        {
            extra = 1;
        }
        circleCenter = transform.position + gameObject.GetComponent<AIScript>().velocity;
        displacement = new Vector3(1, 0, 1);
        displacement *= circleRaduis;
        displacement *= angle * Time.deltaTime;
        angle = (Random.value * jitter);
        if(Random.Range(0,2) == 1)
        {
            angle *= -1;
        }
        gameObject.GetComponent<AIScript>().velocity += (displacement) * extra * Time.deltaTime;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(circleCenter, circleRaduis);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, displacement + (circleCenter - transform.position));
    }
}