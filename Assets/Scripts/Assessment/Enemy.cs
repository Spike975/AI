using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject target;
    public GameObject town;
    public float attack;
    public float attackSpeed;
    private float attacked = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Contains(null))
        {
            targets.Clear();
        }
        if (targets.Count == 0)
        {
            if ((town.transform.position - transform.position).sqrMagnitude >= .25f)
            {
                gameObject.GetComponent<Movement>().velocity += ((town.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
            }
            else
            {
                if ((Time.time - attacked) >= attackSpeed)
                {
                    attacked = Time.time;
                    town.GetComponent<Town>().health -= attack;
                }
            }
        }
        else
        {
            if (target == null)
            {
                GameObject[] t = targets.ToArray();
                if (t.Length != 0)
                {
                    int lowest = 0;
                    for (int i = 1; i < t.Length; i++)
                    {
                        if ((t[lowest].transform.position - transform.position).sqrMagnitude > (t[i].transform.position - transform.position).sqrMagnitude)
                        {
                            lowest = i;
                        }
                    }
                    target = t[lowest];
                }
                else
                {
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                }
            }
            else
            {
                if ((target.transform.position - transform.position).sqrMagnitude < (town.transform.position - transform.position).sqrMagnitude) {
                    if ((target.transform.position - transform.position).sqrMagnitude >= .5f)
                    {
                        gameObject.GetComponent<Movement>().velocity += ((target.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
                    }
                    else
                    {
                        if ((Time.time - attacked) >= attackSpeed)
                        {
                            attacked = Time.time;
                            GameObject.Find(target.name).GetComponent<Status>().health -= attack;
                            if (GameObject.Find(target.name).GetComponent<Status>().health <= 0)
                            {
                                targets.Remove(target);
                                target = null;
                            }
                        }
                    }
                }
                else
                {
                    if ((town.transform.position - transform.position).sqrMagnitude >= .25f)
                    {
                        gameObject.GetComponent<Movement>().velocity += ((town.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
                    }
                    else
                    {
                        if ((Time.time - attacked) >= attackSpeed)
                        {
                            attacked = Time.time;
                            town.GetComponent<Town>().health -= attack;
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!targets.Contains(other.gameObject))
            {
                targets.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targets.Remove(other.gameObject);
        }
    }
}
