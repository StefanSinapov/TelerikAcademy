using System;

namespace University
{
	public class Discipline : IEquatable<Discipline>, ICommentable
	{
		private string topic = string.Empty;
		public uint LecturesCount { get; set; }
		public uint ExercisesCount { get; set; }

		public Discipline(string field, uint lecturesCount, uint exrcisesCount)
		{
			this.Topic = field;
			this.LecturesCount = lecturesCount;
			this.ExercisesCount = exrcisesCount;
		}

		public string Topic
		{
			get { return topic; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Discipline name cant be null or empty");
				topic = value;
			}
		}

		public bool Equals(Discipline other)
		{
			if(this.Topic==other.Topic && this.LecturesCount==other.LecturesCount &&
				this.ExercisesCount==other.ExercisesCount)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public string Comment
		{
			get
			{
				return this.Comment;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Comment cant be null or empty");
				this.Comment = value;
			}
		}

		public override string ToString()
		{
			return string.Format("-> Topic: {0}, Number of lectures: {1}, Number of exercises: {2}",
			this.Topic, this.LecturesCount, this.ExercisesCount);
		}
	}
}
