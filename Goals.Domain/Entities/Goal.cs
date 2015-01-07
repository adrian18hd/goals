using System;
using Goals.SharedKernel;

namespace Goals.Domain.Entities
{
	public class Goal : Entity<Guid>
	{
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int TotalPoints { get; set; }
	}
}