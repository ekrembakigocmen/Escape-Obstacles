
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public GameObject Character;
    public TextMeshProUGUI ScorTxt;
    public static float speed = 450f;
    public int Scor = ScorData.Scor;


    public Rigidbody Rb;
    float HorizontalMove;
    void FixedUpdate()
    {


        Rb.velocity = new Vector3(transform.position.x, transform.position.y, HorizontalMove * Time.deltaTime * speed);


        ScorTxt.text = "Scor: " + Scor.ToString();
    }



    private void OnTriggerExit(Collider coll)
    {
        Scor++;
    }

    public void RightSide()
    {

        HorizontalMove = -1f;

    }

    public void LeftSide()
    {
        HorizontalMove = 1f;

    }

    public void Stop()
    {

        HorizontalMove = 0f;

    }
}
