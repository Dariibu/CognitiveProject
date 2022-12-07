using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Earth : MonoBehaviour
{
    

    [SerializeField] float RotationSpeedX;
    [SerializeField] float RotationSpeedY;

    public static bool ChosenMinigame;

    [SerializeField] float lerpTime;  //Cuanto mayor valor, m�s r�pido va
    [SerializeField] Transform[] posPlaces;
    //[SerializeField] Vector3[] posPlaces;

    public static int chosenPlace;
    float scalefactor =20;
    public GameObject camara;
    [SerializeField] Transform posPruebas; //Usad esto para hacer pruebas de posici�n
    void Update()
    {
        if (!ChosenMinigame)
        {
            //Rota normal
            transform.Rotate(new Vector3(0, RotationSpeedY * Time.deltaTime, (RotationSpeedX) * Time.deltaTime));
        }
        else
        {
            scalefactor += (Time.deltaTime*100);
          
            /*Rota hacia una posici�n distinta, la cual hace que la posici�n del minijuego que queramos se ponga en el centro (a base de prueba y error)
            Es la �nica forma que se me ocurre, la verdad. Si no os gusta alguna posici�n, poned la posici�n del minijuego en concreto en "posPruebas" y haced lo de abajo:
            */

            //Vector3 relativePos = posPruebas.position - transform.position; �� Usad esto en vez del de abajo si quereis probar a cambiar una posici�n en concreto !!
            Vector3 relativePos = posPlaces[chosenPlace - 1].position - transform.position;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), lerpTime * Time.deltaTime);

            if (scalefactor <= 200)
            {
                transform.localScale = new Vector3(scalefactor, scalefactor, scalefactor);

            }
           

                            
        }
    }
}
