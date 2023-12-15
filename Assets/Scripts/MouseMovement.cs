using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject optionsMenu;
    public bool paused;
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    // Start is called before the first frame update
    void Start()
    {
        // Locking the cursor to the middle of the screen and make invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TogglePause()
    {
        optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        paused = !paused; // Toggle the paused state
        UpdateCursorState(); // Update the cursor state
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotation around the x axis (looking up and down)
        xRotation -= mouseY;

        // Clamp the rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        // Rotation around the y axis (looking up and down)
        yRotation += mouseX;

        // Apply the rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }

    void UpdateCursorState()
    {
        //if escape is pressed everything in the game will stop and you will see your cursor
        if (paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        //everything goes like normal and cursor will become invisible
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
