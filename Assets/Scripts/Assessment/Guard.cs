using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject[] path;
    public List<GameObject> enemies;
    public float attack;
    private float attacked;
    public float attackSpeed;
    private GameObject target;
    public GameObject current;
    public GameObject last;
    public GameObject next;
    private int cur;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        target = null;
        cur = 0;
        current = path[cur];
        next = path[cur+1];
        last = path[path.Length-1];
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count != 0)
        {
            if (target == null)
            {
                int low = 0;
                GameObject[] e = enemies.ToArray();
                for (int i = 1; i < enemies.Count; i++)
                {
                    if ((e[i].transform.position - transform.position).sqrMagnitude < (e[low].transform.position - transform.position).sqrMagnitude)
                    {
                        low = i;
                    }
                }
                target = e[low];
            }
            else
            {
                if ((target.transform.position - transform.position).sqrMagnitude >= .5f)
                {
                    Vector3 v = ((target.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {
                    if ((Time.time - attacked) > attackSpeed)
                    {
                        attacked = Time.time;
                        GameObject.Find(target.name).GetComponent<Status>().health -= attack;
                        if (GameObject.Find(target.name).GetComponent<Status>().health <= 0)
                        {
                            enemies.Remove(target);
                            target = null;
                        }
                    }
                }
            }
        }
        else
        {
            if ((current.transform.position - transform.position).sqrMagnitude >= .25f)
            {
                Vector3 v = (((current.transform.position - transform.position).normalized) - gameObject.GetComponent<Movement>().velocity);
                v.y = 0;
                gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
            }
            else
            {
                cur++;
                if (cur == path.Length)
                {
                    cur = 0;
                    gameObject.GetComponent<Status>().money += 5;
                }
                last = current;
                current = next;
                next = path[cur];
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}