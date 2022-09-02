using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class PlayerChildAnim : MonoBehaviour
    {
        private Animator _animator;
        private GameObject _charaFabs;
        private Animator _animatorChild;

        private void Start()
        {
            _charaFabs = gameObject.transform.GetChild(0).gameObject;
            _animatorChild = _charaFabs.GetComponent<Animator>();
            _animator = GetComponent<Animator>();
        }

        public void SetJump()
        {
            _animator?.SetBool("isJump", true);
            _animatorChild?.SetBool("isJump", true);
        }

        public void SetIdle()
        {
            _animator?.SetBool("isJump", false);
            _animatorChild?.SetBool("isJump", false);
        }
    }
}
