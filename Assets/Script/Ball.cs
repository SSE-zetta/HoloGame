using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool jumpKeywaspressed = false;
    private int space_press_count = 0;
    private float horizontal_Input;
    private Rigidbody rigidbody_component;
    [SerializeField] private Transform ground_check;
    //[SerializeField] private Transform SpawnPoint;
    public GameObject level1;
    
    public int life = 2;
    private bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody_component = GetComponent<Rigidbody>();
        level1 = GameObject.Find("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody_component.velocity = new Vector3(10 * horizontal_Input, rigidbody_component.velocity.y, 0);
        //Debug.Log("velocity: " + rigidbody_component.velocity.x);
        Debug.Log("horizontal_in: " + horizontal_Input);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeywaspressed = true;

        }*/
        //horizontal_Input = Input.GetAxis("Horizontal");
        /*
        if (GetComponent<Transform>().position.y <  (level1.GetComponent<Transform>().position.y-2.0f)) {
            GetComponent<Transform>().position = SpawnPoint.transform.position;
            if (life > 1)
            {
                life = life - 1;
                flag = true;
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }*/
    }

    private void FixedUpdate()
    {
        
        
        if (Physics.OverlapSphere(ground_check.position, 0.1f).Length == 1)
        {
            if (flag == true)
            {
                if (jumpKeywaspressed && space_press_count < 3 && rigidbody_component.velocity.y < 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }

                if (jumpKeywaspressed && space_press_count < 3 && rigidbody_component.velocity.y > 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                    jumpKeywaspressed = false;
            }
            else
            {
                if (jumpKeywaspressed && space_press_count < 2 && rigidbody_component.velocity.y < 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }


                if (jumpKeywaspressed && space_press_count < 2 && rigidbody_component.velocity.y > 0)
                {
                    rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                    jumpKeywaspressed = false;
                    space_press_count = space_press_count + 1;
                }
                    jumpKeywaspressed = false;
            }
        }
        else
        {
            space_press_count = 0;
            if (jumpKeywaspressed)
            {
                flag = false;
                rigidbody_component.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
                jumpKeywaspressed = false;
            }
        }



    }

    public void jumpfuction()
    {
        jumpKeywaspressed = true;
    }

    public void horizontal_movement()
    {
        GameObject Slider;
        Slider = GameObject.Find("PinchSlider");
        horizontal_Input = 2.0f * Slider.GetComponent<Microsoft.MixedReality.Toolkit.UI.PinchSlider>().sliderValue - 1.0f;

        //Debug.Log("horizontal_in: " + horizontal_Input);
    }
}
