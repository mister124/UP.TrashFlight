using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    //  private 변수를 Inspector 창에서 직접 노출시키기 위해 사용
    private GameObject coin;
    [SerializeField]
    private float moveSpeed = 5f;

    private float minY = -7;
    [SerializeField]
    private float hp = 1;

    public void SetMoveSpeed(float moveSpeed) {
        this.moveSpeed = moveSpeed;

    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (transform.position.y < minY) {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon") {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0) {
                if (gameObject.tag == "Boss") {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);

        }

    }
}
