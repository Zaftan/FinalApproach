using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Physics;

namespace GXPEngine.Managers
{
	class Collision
	{
		PhysicsObject moving;
		PhysicsObject nonMoving;

		public Collision(PhysicsObject a, PhysicsObject b)
		{
			moving = a;
			nonMoving = b;
		}

		public void Resolve()
		{
			moving.Collide(nonMoving);
		}
	}

	public class PhysicsCollisionManager
	{
        List<PhysicsObject> _movingPhysicsObjects = new List<PhysicsObject>();
		List<PhysicsObject> _allPhysicsObjects = new List<PhysicsObject>();
		float collisionCounter;
		Collision collision;

		private void checkCollisions(PhysicsObject physicsObject, List<PhysicsObject> others)
		{
			foreach (PhysicsObject other in others)
			{
				collisionCounter++;
				
/*				if (other is PhysicsPolygon)
				{
					checkCollisions(physicsObject, ((PhysicsPolygon)other).lines);					
				}*/
				if (physicsObject.Colliding(other))
				{
					collision = new Collision(physicsObject, other);
					break;
				}
			}
		}

		public void Add(PhysicsObject physicsObject)
		{
			if (physicsObject.moving)
			{
				_movingPhysicsObjects.Add(physicsObject);
				return;
			}

			_allPhysicsObjects.Add(physicsObject);
		}
		public void Remove(PhysicsObject physicsObject)
		{
			if (physicsObject.moving)
			{
				_movingPhysicsObjects.Remove(physicsObject);
				return;
			}

			_allPhysicsObjects.Remove(physicsObject);
		}

		private void checkAllCollisions()
		{
			foreach (PhysicsObject physicsObject in _movingPhysicsObjects)
			{
				collision = null;

				checkCollisions(physicsObject, _allPhysicsObjects);

				if (collision != null)
				{
					collision.Resolve();
				}
			}
		}

        internal void Step()
        {
			int i = 1;
			collisionCounter = 0;

			checkAllCollisions();

			while (collision != null)
			{
				i++;
				checkAllCollisions();

				if (i > 200)
				{
					break;
				}
			}

			//Console.Write("CheckedCollisions: " + collisionCounter + " Moving items: " + _movingPhysicsObjects.Count + " ");
		}
    }
}
