using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // buat variabel untuk akses meshRenderer(untuk akses material)
    private MeshRenderer meshRenderer;
    // buat variabel untuk kecepatan animasi
    public float animationSpeed = 1f;

    private void Awake(){
        // akses meshRenderer
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update(){
        // ubah offset texture sesuai dengan animationSpeed
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
