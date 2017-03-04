using UnityEngine;
using System.Collections;

public class PlayerJumpScript : MonoBehaviour {

    public static PlayerJumpScript instance;

    private Rigidbody2D myBody;
    private Animator anim;

    private float forceX, foceY;
    private float tresholdX = 7f;
    private float tresholdY = 14f;

    private bool setPower, didJump;

    void Awake ()
    {
        MakeInstance();
    }

    void MakeInstance ()
    {
        if (instance == null)
            instance = this;
    }

    public void SetPower (bool SetPower)
    {
        this.setPower = SetPower;

        if (setPower)
        {
            Debug.Log("We are setting the power");
        } else
        {
            Debug.Log("We are NOT setting the power");
        }
    }
}
