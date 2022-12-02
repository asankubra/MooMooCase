using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoystickController : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float speed;
    public float turnSpeed;
    private Animator PlayerAnimator;
    public Button swordButton;
    public LayerMask swordMask;
    private Sword lastFindedSword;
    public GameObject HandSword;
    public GameObject DropButton;
    public GameObject AttackButton;
    public GameObject SwordPrefab;
    public GameObject RestartButton;
    public LayerMask stonMask;

    public static Action OnwinGame;
    public static Action OnloseGame;

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsThereSword(out Sword sword))
        {
            lastFindedSword = sword;
            Debug.Log("Kýlýç var.");
        }
        else
        {
            lastFindedSword = null;
        }

        
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
            
        }
        else 
        {
            PlayerAnimator.SetBool("walk", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimator.SetBool("attack", true);
        }
       
    }

    private bool IsThereSword(out Sword findedSword)
    {
        bool result = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2, swordMask);
        result = colliders.Length > 0;
        if (result)
        {
            findedSword = colliders[0].GetComponent<Sword>();
        }
        else
        {
            findedSword = null;
        }
        
        return result;
    }
    public void StopAnimEvent()
    {
        PlayerAnimator.SetBool("attack", false);
    }
    
    public void JoystickMovement()
    {
        if (Mathf.Abs(dynamicJoystick.Direction.magnitude) <= 0)
            return;

        PlayerAnimator.SetBool("walk", true);
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }

    public  void AttackButtonClick()
    {
        Debug.Log("Karakter saldýrýya geçti.");
        
        if (HandSword.activeInHierarchy)
        {
            StartCoroutine(AttackStep());
        }
        
    }private IEnumerator AttackStep()
    {
        PlayerAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(1);
        if (IsThereSton(out Ston ston))
        {
            Vector3 diff = (ston.transform.position - transform.position).normalized;
            float angle = Vector3.Dot(diff, transform.forward);
            Debug.Log("Angle "+ angle);
            if (angle > .8f)
            {
                ston.TakeDamage();
               
            }
           
        }
    }
    
    public void DropButtonClick()
    {
        if (HandSword.activeInHierarchy)
        {
            HandSword.SetActive(false);
            Instantiate(SwordPrefab, HandSword.transform.position, HandSword.transform.rotation);
            DropButton.SetActive(false);
            AttackButton.SetActive(false);
            swordButton.gameObject.SetActive(true);
        }
    }

    public void SwordButtonClick()
    {
        if (lastFindedSword != null)
        {
            Destroy(lastFindedSword.gameObject);
            HandSword.SetActive(true);
            DropButton.SetActive(true);
            AttackButton.SetActive(true);
            swordButton.gameObject.SetActive(false);
        }

        
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool IsThereSton(out Ston findedSton)
    {
        bool result = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2, stonMask);
        result = colliders.Length > 0;
        if (result)
        {
            findedSton = colliders[0].GetComponent<Ston>();
        }
        else
        {
            findedSton = null;
        }

        return result;
    }
   

}
