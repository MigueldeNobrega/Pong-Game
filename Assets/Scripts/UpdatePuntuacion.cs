using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePuntuacion : MonoBehaviour
{



    private TMP_Text textComponent;
    // Start is called before the first frame update

    public uint playerIndex;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();


        //El GetComponent<>() accede a la lista de componentes del objeto al cual este componente este asignado. 
    }

    // Update is called once per frame
    void Update()
    {

        textComponent.text = "Jugador " + (playerIndex +1 )+ ": " + GameManager.instance.GetIndexPuntuacion((int)playerIndex);

    }
}
