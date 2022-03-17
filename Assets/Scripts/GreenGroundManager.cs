
using UnityEngine;

public class GreenGroundManager : MonoBehaviour
{
    public GameObject CaptureSlider;
    float SliderValue;

   

    private void FixedUpdate()
    {
        SliderValue = CaptureSlider.GetComponent<SpawnPointsManager>().CurrentSliderValue;
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
        Rigidbody Rb = collision.collider.GetComponent<Rigidbody>();

        if (Rb != null)
        {
            
            Vector3 Slider = Rb.velocity;
            Slider.x = SliderValue;
            Rb.velocity = Slider;
            

        }
        
    }
}
