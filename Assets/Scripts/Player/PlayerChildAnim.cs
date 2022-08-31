using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class PlayerChildAnim : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetJump()
        {
            _animator?.SetBool("isJump", true);
        }

        public void SetIdle()
        {
            _animator?.SetBool("isJump", false);
        }
    }
}
