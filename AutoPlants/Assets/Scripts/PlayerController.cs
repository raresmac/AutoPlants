using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameObject2;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        characterController.Move(move * Time.deltaTime * 5);
        if(Input.GetKeyDown(KeyCode.Space)){
            characterController.Move(Vector3.up * 5);
        }

        if(Vector3.Distance(transform.position, gameObject2.transform.position) < 2){
            SceneManager.LoadScene("Water");
        }
    }
}
