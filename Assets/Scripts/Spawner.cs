using UnityEngine;

public class Spawner : MonoBehaviour
{
    // buat variabel untuk akses prefab
    public GameObject prefabs;
    // buat variabel spawnRate untuk kecepatan spawn
    public float spawnRate = 1f;
    // buat variabel untuk posisi spawn
    public float minHeight = -1f;
    // buat variabel untuk posisi spawn
    public float maxHeight = 1f;

    // function yg dijalankan pertama kali
    // OnEnable = function yg dijalankan ketika gameobject aktif
    private void OnEnable()
    {
        // InvokeRepeating = function yg dijalankan berulang-ulang
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // function yg dijalankan ketika gameobject tidak aktif
    private void OnDisable()
    {
        // CancelInvoke = function yg membatalkan InvokeRepeating
        CancelInvoke(nameof(Spawn));
    }

    // function untuk spawn prefab
    private void Spawn(){
        // Instantiate = function untuk membuat prefab
        // Instantiate(prefab, posisi, rotasi)
        
        GameObject pipes = Instantiate(prefabs, transform.position, Quaternion.identity);
        // Random.Range = function untuk random angka
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
