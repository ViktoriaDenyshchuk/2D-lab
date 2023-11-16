using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] interactablePrefabs; // Масив префабів
    private float delay = 0.5f;
    private float timer = 0f;
    private int result = 0;
    private int missedObjects = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0f;
            var x = Random.Range(-5f, 5f);
            var y = 8f;
            var position = new Vector3(x, y, 0f);

            int randomIndex = Random.Range(0, interactablePrefabs.Length); // Вибір випадкового індексу з масиву

            GameObject newObject = Instantiate(interactablePrefabs[randomIndex], position, Quaternion.identity);
            var collectable = newObject.GetComponent<DefaultCollectableObject>();

            if (collectable != null)
            {
                collectable.Initialize(OnCollectObject, OnMissedObject);
            }
        }
    }

    private void OnCollectObject()
    {
        result++;
        Debug.Log(" - " + result + " bal - ");
    }

    private void OnMissedObject()
    {
        missedObjects++;

        if (missedObjects >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
