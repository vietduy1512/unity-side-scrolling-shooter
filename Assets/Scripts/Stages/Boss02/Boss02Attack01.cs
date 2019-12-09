using UnityEngine;

public class Boss02Attack01 : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject appearPrefab;
    GameObject[] Appearance = new GameObject[5];

    [SerializeField] float spawnDistance = 12f;

    [SerializeField] float beginAttackWave = 1; //Enemy in the begining
    [SerializeField] float attackWaveDelay = 5f;

    [SerializeField] int maxAttacks; //Max enemies


    bool notAppearing = true;
    Vector3[] offset = new Vector3[5];

    Color[] rend = new Color[5];

    void Start()
    {

        beginAttackWave += 2;
        attackWaveDelay += 2;
    }

    void Update()
    {
        beginAttackWave -= Time.deltaTime;

        AttackAppearance();
    }

    void AttackAppearance()
    {
        if (beginAttackWave <= 0 && !notAppearing)
        {
            beginAttackWave = attackWaveDelay;

            for (int j = 0; j < maxAttacks; j++)
            {
                Instantiate(enemyPrefab, offset[j], Quaternion.identity);
                Destroy(Appearance[j]);
            }
            notAppearing = true;
        }
        else if (beginAttackWave <= 2 && notAppearing)
        {
            // Delay Attack wave
            for (int j = 0; j < maxAttacks; j++)
            {
                RandomPosition(j);
                notAppearing = false;
                Appearance[j] = (GameObject)Instantiate(appearPrefab, offset[j] + new Vector3(4f, -0.5f, 0), Quaternion.identity);
                //Appearance [j].transform.localScale = new Vector3 (0, 0, 0);
                rend[j] = Appearance[j].GetComponent<Renderer>().material.color;
                rend[j].a = 0;
                Appearance[j].GetComponent<Renderer>().material.color = rend[j];
            }
        }
        else if (beginAttackWave <= 2 && !notAppearing)
        {
            for (int j = 0; j < maxAttacks; j++)
            {
                if (/*Appearance[j].transform.localScale == new Vector3 (1f, 1f, 1f)*/rend[j].a == 1)
                {
                    return;
                }
                //Appearance[j].transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
                rend[j].a += 0.03f;
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
