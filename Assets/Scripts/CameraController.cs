using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minCampos, maxCampos;
    public GameObject seguir;
    public float movSuave;

    private Vector2 velocidad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velocidad.x, movSuave);
        float posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velocidad.y, movSuave);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCampos.x, maxCampos.x),
            Mathf.Clamp(posY + 0.75f, minCampos.y, maxCampos.y),
           transform.position.z);
    }
}
