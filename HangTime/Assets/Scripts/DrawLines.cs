using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    [SerializeField]
    private GameObject LineGeneratorPrefab;
    public Transform PlayerTransform;
    public Transform CameraTransform;
    public Transform reticalPosition;
    public float xOffset;
    public float yOffset;
    public int rayLength;
    private GameObject newLineGen;
    private LineRenderer lRend;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLineGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camDir = reticalPosition.position - CameraTransform.position;
        camDir.Normalize();
        camDir = camDir * rayLength;
        //Debug.Log(reticalPosition.position);
        lRend.SetPosition(0, PlayerTransform.position);
        lRend.SetPosition(1, PlayerTransform.position + camDir);
    }
    private void SpawnLineGenerator()
    {
        newLineGen = Instantiate(LineGeneratorPrefab);
        lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.SetPosition(0, PlayerTransform.position);
        lRend.SetPosition(1, new Vector3(xOffset,yOffset,0));

        //Destroy(newLineGen, 5);
    }
}
