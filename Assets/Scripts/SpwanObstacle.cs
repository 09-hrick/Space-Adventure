using UnityEngine;

public class SpwanObst : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private GameObject heart;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
 
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            int spawnchance = Random.Range(0, 10);
            if(spawnchance == 5)
            {
                Spawn(heart);
            }
            else
            {
                Spawn(obstacle);
            }
            spawnTime = Time.time+timeBetweenSpawn;
        }
        
    }
    void Spawn(GameObject objectToSpawn)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Instantiate(objectToSpawn, transform.position + new Vector3(randomX, randomY, 0),transform.rotation);

    }
}
