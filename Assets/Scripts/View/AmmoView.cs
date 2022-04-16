using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobilePang;
using MobilePang.Model;

namespace MobilePang.View
{
    public class AmmoView : MVCHelper
    {
        float _speed;
        float _lifetime;

        Rigidbody2D _rb;

        #region Unity Callbacks
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _speed = Model.GetAmmo().Speed;
            _lifetime = Model.GetAmmo().Lifetime;

            transform.position = View.Player.SpawnPoint.position;
            _rb.AddForce(Vector2.up * _speed, ForceMode2D.Impulse);
            
            StartCoroutine(DeactivateAfterSeconds(_lifetime));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            gameObject.SetActive(false);
        }

        #endregion

        private IEnumerator DeactivateAfterSeconds(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.SetActive(false);
        }
    }
}