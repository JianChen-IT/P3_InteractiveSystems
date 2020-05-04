using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Collector : MonoBehaviour
{
    private Rigidbody rb;
    private SpawnObjects spawnObjects;
    public AudioSource audioSource;
    public TMP_Text winText;
    private int counter = 0;
    // Start is called before the first frame update
    public void SetSpawner(SpawnObjects spawner)
    {
        spawnObjects = spawner;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 20)
        {
            winText.text = "Mission complete!";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject,0);
            audioSource.Play();
            counter += 1;
        }
    }
}
