using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float force = 4f;
    float moveAmount;
    Vector3 direction;

    int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }
        moveAmount = force * Time.deltaTime;
        transform.Translate(direction * moveAmount);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            score++;
            scoreText.text = score.ToString();
            Debug.Log(score);
            Destroy(other.gameObject);
        }
    }
}
