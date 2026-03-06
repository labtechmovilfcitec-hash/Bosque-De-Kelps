using UnityEngine;

public class CausticAnimator : MonoBehaviour
{
    [Header("Frames de Cáusticas")]
    public Texture2D[] causticFrames;

    [Header("Velocidad de Animación")]
    [Range(8, 30)]
    public float fps = 15f;

    [Header("Scroll de Textura")]
    public float speedX = 0.05f;
    public float speedY = 0.03f;

    private Material mat;
    private int currentFrame = 0;
    private float timer = 0f;
    private Vector2 offset;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        if (causticFrames != null && causticFrames.Length > 0)
            mat.SetTexture("_BaseMap", causticFrames[0]);
    }

    void Update()
    {
        if (causticFrames != null && causticFrames.Length > 0)
        {
            timer += Time.deltaTime;
            if (timer >= 1f / fps)
            {
                timer = 0f;
                currentFrame = (currentFrame + 1) % causticFrames.Length;
                mat.SetTexture("_BaseMap", causticFrames[currentFrame]);
            }
        }

        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}