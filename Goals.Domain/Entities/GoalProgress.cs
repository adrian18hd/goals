using System;
using Goals.SharedKernel;

namespace Goals.Domain.Entities
{
	public class GoalProgress : Entity<Guid>
	{
		public Guid GoalId { get; set; }
		public DateTime Date { get; set; }
		public int Points { get; set; }
	}
}