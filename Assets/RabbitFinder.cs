using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFinder : MonoBehaviour
{
    [SerializeField] Rabbit _rabbit;

    Gender _myGender;
    

    private void Start()
    {
        if(_rabbit != null)
            _myGender = _rabbit.gender;
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider _col = other;

        if(_col.CompareTag("Rabbit"))
        {
            Rabbit _othrabbit = _col.GetComponent<Rabbit>();

            if(_othrabbit.available)
            {
                //if(_rabbit)
                if(_myGender != _othrabbit.gender) // male and Female scenario
                {
                    //love
                    _rabbit.MakeLove();
                    _othrabbit.MakeLove();
                  
                }
                else // differemt genders scenario
                {
                    //attack
                    _rabbit.Attack();
                    _othrabbit.Attack();
                }
            }
        }
    }


}
