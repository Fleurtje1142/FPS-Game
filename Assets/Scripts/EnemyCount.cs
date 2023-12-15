using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public int enemyCount;
    public GameObject Won;
    public TMP_Text scoreText;


    // Update is called once per frame
    void Update()
    {
        //counts amount of enemies that have tag enemy and shows on screen amount of spiders left
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        scoreText.text = "Zombies left " + enemyCount;

        //if there are no enemies show the won screen and mouse will be visible
        if (enemyCount == 0)
        {
            Won.gameObject.SetActive(true);
            UpdateCursorState();
        }

    }

    //shows that mouse will be visible and not continuesly disappears
    void UpdateCursorState()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
