using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrincipalCharacter : MonoBehaviour
{
    public static PrincipalCharacter Instance;
    private PlayerHealth playerHealth;
    private float movementSpeed = 2.0f;

    public float rotationSpeed = 250.0f;

    private float sprintSpeed = 6.0f;

    private bool isSprinting = false;

    private Animator anim;

    public float x, y, mouseX;

    public float initialSpeed;
    public float speedCrouch;

    public AudioSource steps;

    private bool Hactive;
    private bool Vactive;
    public Image staminaBar;
    public float stamina, maxStamina;
    public float attackCost;
    public float runCost;
    public float chargeRate;
    public AudioSource parry;
    private Coroutine staminaRegen;
    void Move()
    {
        if (Input.GetButton("Fire2"))
        {

            anim.SetBool("Block", true);

        }
        else
        {
            anim.SetBool("Block", false);

        }


    }
    void Start()
    {

        Instance = this;

        playerHealth = GetComponent<PlayerHealth>();

        anim = GetComponent<Animator>();

        initialSpeed = movementSpeed;
        speedCrouch = movementSpeed * 0.5f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!playerHealth.canMove) return;

        bool canAttack = stamina >= attackCost;
        bool canRun = stamina > 0;

        if (Input.GetKeyDown(KeyCode.V) && canAttack)
        {

            anim.SetTrigger("Parry");
            parry.Play();
            stamina -= attackCost;

            if (stamina < 0) stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;

            if (staminaRegen != null) StopCoroutine(staminaRegen);
            staminaRegen = StartCoroutine(RechargeStamina());
        }

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");

        transform.Translate(x * Time.deltaTime * movementSpeed, 0, 0);
        transform.Rotate(0, mouseX * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);

        anim.SetFloat("SpeedX", x);
        anim.SetFloat("SpeedY", y);

        if (Input.GetButtonDown("Horizontal"))
        {
            if (Vactive == false)
            {
                Hactive = true;
                steps.Play();
            }

        }

        if (Input.GetButtonUp("Horizontal"))
        {

            Hactive = false;
            if (Vactive == false)
            {
                steps.Pause();
            }

        }

        if (Input.GetButtonDown("Vertical"))
        {

            if (Hactive == false)
            {
                Vactive = true;
                steps.Play();
            }

        }

        if (Input.GetButtonUp("Vertical"))
        {
            Vactive = false;
            if (Hactive == false)
            {
                steps.Pause();
            }
        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
            movementSpeed = speedCrouch;
            this.transform.localScale = new Vector3(1, 0.60f, 1);
        }
        else
        {
            anim.SetBool("Crouch", false);
            movementSpeed = initialSpeed;
            this.transform.localScale = new Vector3(1, 1, 1);
        }


        if (Input.GetKey(KeyCode.LeftShift) && canRun)
        {
            isSprinting = true;
            movementSpeed = sprintSpeed;
            stamina -= runCost * Time.deltaTime;

            if (stamina < 0) stamina = 0;
            staminaBar.fillAmount = stamina / maxStamina;

            if (staminaRegen != null) StopCoroutine(staminaRegen);
            staminaRegen = StartCoroutine(RechargeStamina());
        }
        else
        {
            isSprinting = false;
            movementSpeed = (Input.GetKey(KeyCode.LeftControl)) ? speedCrouch : initialSpeed;

        }

        Move();
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(5f);

        while (stamina < maxStamina)
        {
            float currentChargeRate = anim.GetBool("Crouch") ? chargeRate * 4.0f : chargeRate;

            stamina += currentChargeRate / 10.0f;
            if (stamina > maxStamina) stamina = maxStamina;
            staminaBar.fillAmount = stamina / maxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
