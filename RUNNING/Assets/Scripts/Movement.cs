using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    public TextMeshPro myText;

    public float totalDistance;
    private Vector3 previousPosition;
    private Animator anim;

    public GameObject menuUI; //disable UI on load

    void Start()
    {
        anim = GetComponent<Animator>();
        previousPosition = transform.position;  //just so we don't go crazy on the first frame
    }

    void Update()
    {
        myText.text = totalDistance.ToString();

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            anim.SetBool("isRunning", true);
        }
        else anim.SetBool("isRunning", false);


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        float distanceThisFrame = Vector3.Distance(transform.position, previousPosition);
        totalDistance += distanceThisFrame;

        previousPosition = transform.position;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    } 
    
    IEnumerator AutoSave()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Saved");
            SavePlayer();
        }
    }

    public void LoadPlayer()
    {
        Debug.Log("Player Loaded Successfully");

        PlayerData data = SaveSystem.LoadPlayer();

        totalDistance = data.distance;

        menuUI.SetActive(false);
    }
}
