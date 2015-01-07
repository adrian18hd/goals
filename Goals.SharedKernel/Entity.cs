using System;

namespace Goals.SharedKernel
{
	public abstract class Entity<TId> : IEquatable<Entity<TId>>
	{
		public TId Id { get; protected set; }

		protected Entity(TId id)
		{
			if (Equals(id, default(TId)))
			{
				throw new ArgumentException("The ID cannot be the type's default value.", "id");
			}
			Id = id;
		}

		protected Entity()
		{
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public bool Equals(Entity<TId> other)
		{
			return other != null && Id.Equals(other.Id);
		}
	}
}