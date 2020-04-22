using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    public Transform[] backgrounds;
    public float parallaxScale = 0.5f;  //相机移动比例
    public float smooth = 5f;
    public float layerScale = 0.5f;

    private Transform CamTransfrom;
    private Vector3 previousCamPos;
    // Start is called before the first frame update
    private void Awake()
    {
       // CamTransfrom = GameObject.FindGameObjectsWithTag("MainCamera").transform;
        CamTransfrom = Camera.main.transform;
    }
    void Start()
    {
        previousCamPos = CamTransfrom.position;
    }

    // Update is called once per frame
    void Update()
    {
        float parallax = (previousCamPos.x - CamTransfrom.position.x) * parallaxScale;
        for(int i = 0; i < backgrounds.Length; i++)
        {
            float targetX = backgrounds[i].position.x + parallax * (1 + i * layerScale);
            Vector3 targetPos = new Vector3(targetX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPos, smooth * Time.deltaTime);

        }
        previousCamPos = CamTransfrom.position;
    }
}
