using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DudeObject : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _particles;

    public class OnSpikeCollisionEventArgs
    {
        public DudeObject Sender { get; }

        public OnSpikeCollisionEventArgs(DudeObject sender)
        {
            Sender = sender;
        }
    }

    public event Action<OnSpikeCollisionEventArgs> OnSpikeCollision = null;

    public void SetSpeedValue(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<SpikeGroup>(out var spike))
        {
            if (spike.IsAcive)
            {
                var spawner = this.transform.parent.gameObject.GetComponent<DudeSpawner>();
                if (spawner != null) spawner.SpawnParticles(_particles, this.transform.position);
                OnSpikeCollision?.Invoke(new OnSpikeCollisionEventArgs(this));
            }
        }
        else if (other.TryGetComponent<PickableItem>(out var item))
        {
            item.Pickup();
        }
    }
}
