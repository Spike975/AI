using UnityEngine;

public class Mine : MonoBehaviour
{
    private GameObject mine;
    private GameObject storage;
    public float capacity;
    public float refill;
    public float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        mine = GameObject.Find("Mine");
        storage = GameObject.Find("Storage");
        capacity = 0;
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (capacity >= 50)
        {
            gameObject.GetComponent<Movement>().speed = .5f;
            if ((storage.transform.position - transform.position).sqrMagnitude >= 1)
            {
                gameObject.GetComponent<Movement>().velocity += ((storage.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
            }
            else
            {
                storage.GetComponent<Storage>().mine += capacity;
                gameObject.GetComponent<Status>().money += 3;
                capacity = 0;
            }
        }
        else
        {
            gameObject.GetComponent<Movement>().speed = 1;
            if ((mine.transform.position -gameObject.transform.position).sqrMagnitude <= 1) {
                if ((Time.time - lastTime) >= refill)
                {
                    lastTime = Time.time;
                    capacity++;
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                }
            }
            else
            {
                gameObject.GetComponent<Movement>().velocity += ((mine.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
            }
        }
    }
}