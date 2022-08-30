using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paintastic.Player
{
    public class PlayerChildAnim : MonoBehaviour
    {

        private Animator _animator;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetJump()
        {
            _animator.SetBool("isJump", true);
        }

        public void SetIdle()
        {
            _animator.SetBool("isJump", false);
        }
    }
}

