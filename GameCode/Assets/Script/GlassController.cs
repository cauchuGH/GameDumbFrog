using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    public GameObject frontGlass;
    public GameObject mainCamera;
    public GameObject gameController;
    public float CSpeed;

    GameObject obj;

    float randomX, randomY; // lay toa do ngau nhien X, Y de sinh glass moi

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        CSpeed = 2f;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // tao Glass va kiem diem
        if (obj.transform.position.x < -12)
        {
            CreateGlass();
            gameController.GetComponent<GameController>().GetPoint();
        }

        // Dieu chinh vi tri camera
        ChancePosCamera();

    }

    void CreateGlass()
    {
        randomX = Random.Range(1.3f, 3.3f);

        if (frontGlass.transform.position.y > 10f)
        {
            randomY = Random.Range(-1.5f, 0f);
        }
        else if (frontGlass.transform.position.y < 10f)
        {
            randomY = Random.Range(0f, 1.5f);
        }
        obj.transform.position = new Vector3(frontGlass.transform.position.x + randomX, frontGlass.transform.position.y + randomY, 0);

    }

    void ChancePosCamera() // Chance Position Camera
    {
        if (frontGlass.transform.position.x < 0.3 && frontGlass.transform.position.x > -0.3)
        {
            Vector3 newCamPos = new Vector3(0, obj.transform.position.y + 2.5f, mainCamera.transform.position.z);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newCamPos, 0.3f*CSpeed * Time.deltaTime);
        }
    }
}
