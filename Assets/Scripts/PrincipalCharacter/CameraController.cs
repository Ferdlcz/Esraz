using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speedRotation = 3.0f;
    public float minAngle = -60.0f;
    public float maxAngle = 60.0f;

    public float walkBobbingSpeed = 14f;
    public float bobbingAmount = 0.05f;

    private bool gamePaused = false;
    private float rotX = 0;
    private float defaultRotZ;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        defaultRotZ = transform.localRotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }

        if (!gamePaused)
        {
            ApplyRotation();
            ApplyHeadBobbing();
        }
    }

    void ApplyRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * speedRotation;
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, minAngle, maxAngle);

        // Aplicar rotación en el eje Y
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }

    void ApplyHeadBobbing()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + walkBobbingSpeed * Time.deltaTime;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        if (waveslice != 0)
        {
            float rotateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            rotateChange = totalAxes * rotateChange;

            // Aplicar rotación en el eje Z
            transform.localRotation *= Quaternion.Euler(0, 0, defaultRotZ + rotateChange);
        }
    }
}

