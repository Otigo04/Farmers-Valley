using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Einstellbare Bewegungsgeschwindigkeit
    public float speed = 5f;

    // Referenz auf das Rigidbody2D (für Physik-basierte Kollisionen)
    private Rigidbody2D rb;

    void Start()
    {
        // Hole das Rigidbody2D-Komponente des GameObjects
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    [System.Obsolete]
    void Update()
    {
        // Abrufen der Eingaben ohne Glättung (sorgt für sofortiges Stoppen)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Erstellen eines Vektors aus den Eingaben und Normalisieren, um konstante Geschwindigkeit zu gewährleisten
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Setzen der Geschwindigkeit. Wenn keine Taste gedrückt wird, wird die Geschwindigkeit 0.
        rb.velocity = movement * speed;
    }
}
