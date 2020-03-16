using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public GameObject[] path;
    public List<GameObject> enemies;
    public int attack;
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
        
        path = GameObject.FindGameObjectsWithTag("Path");
        for(int i = 0; i < path.Length; i++)
        {
            for (int x = i; x < path.Length; x++)
            {
                if (path[x].name == "Path " + i)
                {
                    GameObject temp = path[x];
                    path[x] = path[i];
                    path[i] = temp;
                    break;
                }
            }
        }
        int start = 0;
        for (int i = 1; i < path.Length; i++)
        {
            if ((path[i].transform.position - transform.position).sqrMagnitude < (path[start].transform.position - transform.position).sqrMagnitude)
            {
                start = i;
            }
        }
        cur = start;
        enemies = new List<GameObject>();
        target = null;
        current = path[cur];
        next = path[cur+1];
        last = path[(cur-1) > 0 ? cur-1 : path.Length-1];
    }

    // Update is called once per frame
    void Update()
    {
        //Removes any missing or null gameobjects
        for (int i = enemies.Count - 1; i > -1; i--)
        {
            if(enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
        //Check to see if there are any enemies close
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
    //If an enemy enters the area of the guard, add it to the list if it isn't there
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (!enemies.Contains(other.gameObject))
            {
                enemies.Add(other.gameObject);
            }
        }
    }
    //Removes enemy if it exits the area
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }
}