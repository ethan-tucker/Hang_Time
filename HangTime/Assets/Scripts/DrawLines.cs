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
    public float range = 100f;
    private GameObject lastObjectHit = null;
    // Start is called before the first frame update
    void Start()
    {
        SpawnLineGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 retDir = reticalPosition.position - CameraTransform.position;
        retDir.Normalize();
        retDir = retDir * rayLength;

        if(true)
        {
            Shoot(retDir);
        }
        //Debug.Log(reticalPosition.position);
        lRend.SetPosition(0, PlayerTransform.position);
        lRend.SetPosition(1, PlayerTransform.position + retDir);
    }
    private void SpawnLineGenerator()
    {
        newLineGen = Instantiate(LineGeneratorPrefab);
        lRend = newLineGen.GetComponent<LineRenderer>();

        lRend.SetPosition(0, PlayerTransform.position);
        lRend.SetPosition(1, new Vector3(xOffset,yOffset,0));

        //Destroy(newLineGen, 5);
    }
    private void Shoot(Vector3 retDir)
    {
        RaycastHit hit;
        // To check in a circle around the reticle retDir would need to be changed
        if(Physics.Raycast(CameraTransform.position, retDir, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            GameObject curObjectHit = hit.transform.gameObject;
            if(lastObjectHit)
            {
                if(lastObjectHit.name != curObjectHit.name)
                {
                    lastObjectHit.GetComponent<MeshRenderer>().material.color = Color.blue;  
                }
            }
            lastObjectHit = curObjectHit;
            MeshRenderer mr= hit.transform.GetComponent<MeshRenderer>();
            mr.material.color = Color.red;
        }
        // will be run if none of the rays hit
        else{
            if(lastObjectHit)
            {
                lastObjectHit.GetComponent<MeshRenderer>().material.color = Color.blue;
                lastObjectHit = null;
            }
        }
    }
}
