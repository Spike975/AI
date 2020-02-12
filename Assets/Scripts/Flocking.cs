using UnityEngine;

public class Flocking : MonoBehaviour
{
    public GameObject[] flock;
    public float raduis;
    private Vector3 totalVelocity;

    private void Start()
    {
        flock = GameObject.FindGameObjectsWithTag("Flock");
        for (int i = 0; i < flock.Length; i++)
        {
            if (flock[i].name == gameObject.name)
            {
                GameObject[] temp = new GameObject[flock.Length-1];
                for (int x = 0; x < flock.Length-1; x++)
                {
                    if (x < i)
                    {
                        temp[x] = flock[x];
                    }
                    else
                    {
                        temp[x] = flock[x + 1];
                    }
                }
                flock = temp;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int total = 0;
        Vector3 separateForce = new Vector3();
        Vector3 alignForce = new Vector3();
        Vector3 cohesionForce = new Vector3();
        foreach (GameObject i in flock)
        {
            float distance = (transform.position - i.transform.position).sqrMagnitude;
            if (distance < raduis)
            {
                separateForce += transform.position - i.transform.position;
                alignForce += i.GetComponent<AIScript>().velocity;
                cohesionForce += i.transform.position - transform.position;
                total++;
            }
        }
        separateForce /= total;
        alignForce /= total;
        cohesionForce /= total;
        totalVelocity = (separateForce - gameObject.GetComponent<AIScript>().velocity) + (alignForce - gameObject.GetComponent<AIScript>().velocity) + (cohesionForce - gameObject.GetComponent<AIScript>().velocity);
        gameObject.GetComponent<AIScript>().velocity += totalVelocity * Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, raduis/2);
    }
}