using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject obstacle;
	public GameObject powerup;
	public GameObject sphere;

	float timeElapsed = 0;
	float spawnCycle = 0.6f;
	bool spawnPowerup = true;

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnPowerup)
			{
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-4, 6), pos.y, pos.z);

			}
			else
			{
				temp = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-4, 6), pos.y, pos.z);
			}

			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
	}
}
