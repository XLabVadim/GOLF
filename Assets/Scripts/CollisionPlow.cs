using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class CollisionPlow : MonoBehaviour
    {
		[SerializeField]
		private UnityEvent<Collision> onCollisionStone;

		private void OnCollisionEnter(Collision other)
		{
			onCollisionStone.Invoke(other);
		}
    }
}

