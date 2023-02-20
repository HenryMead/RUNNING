using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    public TextMeshPro myText;

    public float totalDistance;
    private Vector3 previousPosition;

    void Start()
    {
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
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        float distanceThisFrame = Vector3.Distance(transform.position, previousPosition);
        totalDistance += distanceThisFrame;
        Debug.Log("Distance this frame: " + distanceThisFrame.ToString() + "   Total Distance: " + totalDistance.ToString());

        previousPosition = transform.position;
    }
}
