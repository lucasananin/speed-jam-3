using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    [SerializeField] float _drag = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var _playerMovement = collision.GetComponent<PlayerMovement>();
            _playerMovement.SetDrag(_drag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var _playerMovement = collision.GetComponent<PlayerMovement>();
            _playerMovement.ResetDrag();
        }
    }
}
