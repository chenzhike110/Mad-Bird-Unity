using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    [SerializeField] private float _launchPower = 500;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        if (transform.position.y > 10 || 
            transform.position.y < -10 ||
            transform.position.x < -15 ||
            transform.position.x > 15) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Awake() {
        _initialPosition = transform.position;
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp() {
        GetComponent<LineRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = (_initialPosition - transform.position) * _launchPower;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

}
