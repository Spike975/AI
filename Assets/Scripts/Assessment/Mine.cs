using UnityEngine;

public class Mine : MonoBehaviour
{
    private GameObject mine;
    private GameObject storage;
    public int mined;
    private float lastTime;
    private bool filled = false;

    // Start is called before the first frame update
    void Start()
    {
        mine = GameObject.Find("Mine");
        storage = GameObject.Find("Storage");
        mined = 0;
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (storage.GetComponent<Storage>().mine < storage.GetComponent<Storage>().mineCap)
        {
            if (filled)
            {
                if ((storage.transform.position - transform.position).sqrMagnitude >= .5f)
                {
                    Vector3 v = ((storage.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {

                    if ((Time.time - lastTime) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                    {
                        lastTime = Time.time;
                        storage.GetComponent<Storage>().mine++;
                        mined--;
                        if (mined == 0)
                        {
                            gameObject.GetComponent<Status>().money += 3;
                            filled = false;
                            gameObject.GetComponent<Movement>().speed = 1;
                            gameObject.GetComponent<Movement>().velocity = new Vector3();
                            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                            gameObject.GetComponent<TownsFolk>().last = 0;
                            gameObject.GetComponent<Mine>().enabled = false;
                        }
                    }
                }
            }
            else
            {
                if ((mine.transform.position - gameObject.transform.position).sqrMagnitude <= 1) {
                    if ((Time.time - lastTime) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                    {
                        lastTime = Time.time;
                        mined++;
                        if (mined == gameObject.GetComponent<TownsFolk>().capacity)
                        {
                            filled = true;
                        }
                        gameObject.GetComponent<Movement>().velocity = new Vector3();
                        gameObject.GetComponent<Movement>().speed = .5f;
                    }
                }
                else
                {
                    gameObject.GetComponent<Movement>().velocity += ((mine.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity) * Time.deltaTime;
                }
            }
        }
        else
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
            gameObject.GetComponent<TownsFolk>().last = 0;
            gameObject.GetComponent<Mine>().enabled = false;
        }
    }
}