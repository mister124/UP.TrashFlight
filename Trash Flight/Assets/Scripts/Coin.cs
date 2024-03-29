using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7;

    // Start is called before the first frame update -> 첫 frame 전 호출
    void Start()
    {
        Jump();
    }

    void Jump() {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        float randomJumpForce = Random.Range(4f,8f);
        Vector2 jumpvelocity = Vector2.up * randomJumpForce;
        jumpvelocity.x = Random.Range(-2f,2f);
        rigidbody.AddForce(jumpvelocity, ForceMode2D.Impulse);
        // .AddFoce: Object에 힘 가하기
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
