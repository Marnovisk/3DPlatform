using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IDamagable
    {
        public void TakeDamage(int amount);
    }

    public interface IEnemy
    {
        
    }

    public interface IBossStates
    {
        void Enter();
        void Update();
        void Exit();
    }

    public interface ITargetWeapon
    {
        public void Init(Transform pTarget);
    }

