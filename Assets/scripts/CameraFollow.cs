using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xDistance = 2f;
    public float yDistance = 2f;
    public float xSmooth = 5f;
    public float ySmooth = 5f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    public Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
    }
    bool CheckXDistance()
    {
        return Mathf.Abs(transform.position.x - player.transform.position.x) > xDistance;
    }
    bool CheckYDistance()
    {
        return Mathf.Abs(transform.position.y - player.transform.position.y) > yDistance;
    }
    void TrackPlayer()
    {
        float fTargetX = transform.position.x;
        float fTargety = transform.position.y;
        if (CheckXDistance())
        {
            fTargetX = Mathf.Lerp(transform.position.x, player.transform.position.x, 
                                        Time.deltaTime * xSmooth);
            fTargetX = Mathf.Clamp(fTargetX, minXAndY.x, maxXAndY.x);
        }
        if (CheckYDistance())
        {
            fTargety = Mathf.Lerp(transform.position.y, player.transform.position.y,
                                        Time.deltaTime * ySmooth);
            fTargety = Mathf.Clamp(fTargety, minXAndY.y, maxXAndY.y);
        }

        transform.position = new Vector3(fTargetX, fTargety, transform.position.z);
    }
}
