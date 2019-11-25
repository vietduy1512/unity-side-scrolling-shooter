using UnityEngine;

public class Boss02Attack02 : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject appearPrefab;
    GameObject[] Appearance = new GameObject[5];

    public float spawnDistance = 12f;

    public float beginAttackWave = 1; //Enemy in the begining
    public float attackWaveDelay = 5f;

    public int maxAttacks; //Max enemies

    GameObject player;

    bool notAppearing = true;
    Vector3[] offset = new Vector3[5];

    Color[] rend = new Color[5];

    void Start()
    {
        player = GameObject.Find("PlayerShip(Clone)");
        beginAttackWave += 2;
        attackWaveDelay += 2;
    }

    // Update is called once per frame
    void Update()
    {
        beginAttackWave -= Time.deltaTime;

        AttackAppearance();
    }

    void AttackAppearance()
    {
        if (player == null) player = GameObject.Find("PlayerShip(Clone)");

        if (beginAttackWave <= 0 && !notAppearing)
        {

            beginAttackWave = attackWaveDelay;

            for (int j = 0; j < maxAttacks; j++)
            {
                Instantiate(enemyPrefab, offset[j], Quaternion.identity);
                Destroy(Appearance[j]);
            }
            if (player != null)
            {

                Instantiate(enemyPrefab, offset[maxAttacks], Quaternion.identity);
                Destroy(Appearance[maxAttacks]);
            }
            notAppearing = true;
        }
        else if (beginAttackWave <= 1 && notAppearing)
        {

            // Delay Attack wave
            for (int j = 0; j < maxAttacks; j++)
            {
                RandomPosition(j);
                notAppearing = false;
                Appearance[j] = (GameObject)Instantiate(appearPrefab, offset[j], Quaternion.identity);
                //Appearance [j].transform.localScale = new Vector3 (0, 0, 0);
                rend[j] = Appearance[j].GetComponent<Renderer>().material.color;
                rend[j].a = 0f;
                Appearance[j].GetComponent<Renderer>().material.color = rend[j];
            }
            if (player != null)
            {
                offset[maxAttacks] = player.transform.position;
                Appearance[maxAttacks] = (GameObject)Instantiate(appearPrefab, offset[maxAttacks], Quaternion.identity);
            }
        }
        else if (beginAttackWave <= 1 && !notAppearing)
        {

            for (int j = 0; j < maxAttacks; j++)
            {
                if (/*Appearance[j].transform.localScale == new Vector3 (1f, 1f, 1f)*/rend[j].a == 1)
                {
                    return;
                }
                //Appearance[j].transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
                rend[j].a += 0.05f;
                Appearance[j].GetComponent<Renderer>().material.color = rend[j];
            }
        }
    }
    void RandomPosition(int j) // The number of loop
    {
        offset[j] = Random.onUnitSphere;

        offset[j].z = 0;

        offset[j] = offset[j].normalized * spawnDistance;

        offset[j].y /= 2;

        offset[j] = offset[j] + new Vector3(-7f, 0, 0); // Attack to the left side
    }
}
