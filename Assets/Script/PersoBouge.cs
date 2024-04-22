using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PersoBouge : MonoBehaviour
{
    public float vitesse ;

    public float puissanceSaut;

    public int nombre_sauts;

    public float friction;

    public Animator mon_animator;

    int nb_saut;

    Vector3 direction;

    Rigidbody rb;

    bool auSol;
}
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void TourneAvecCamera(){

    Vector3 targetForward = Camera.main.transform.forward;
    targetForward.y = 0f;
    transform.forward = targetForward.normalized;
}
    TourneAvecCamera();

direction = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")

private void FixeUpdate(){
    Bouger();
}

void Bouger(){
    if(auSol)
    {
        rb.AddForce(direction.normalized * vitesse * 10f, ForceMode.Force);
    }
    else
    {

        rb.AddForce(direction.normalized * vitesse, Forcemode.Force);
    }

}

void Sauter() {
    if(nb_Saut > 0){
        
    rb.velocity = new Vector3(rb.Velocity.x, 0f,rb.velocity.z);

    rb.AddForce(transform.up * puissanceSaut, ForceMode.Impulse);
    
    nb_saut -= 1;

    mon_animator.SetTrigger("saut");
    }
}


private void OnCollisionEnter(Collision collision) {
      if(collision.transform.tag == "sol") {
           auSol = true;
           nb_saut = nombre_sauts;
            
    }
}


private void OnCollisionExit(Collision collision) {
      if(collision.transform.tag == "sol") {
           auSol = false;
            
    }
}

