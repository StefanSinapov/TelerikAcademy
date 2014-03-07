using System;
using System.Collections.Generic;


namespace BitArrayProject
{
	public class BitArray64 : IEnumerable<int>
	{
		private ulong Value { get; set; }

		public BitArray64(ulong number = 0)
		{
			this.Value = number;
		}

		public ulong this[int index]
		{
			get
			{
				if (index < 0 || index > 63)
					throw new ArgumentOutOfRangeException("Index must be in interval [0-63]");
				return ((this.Value >> index) & 1);
			}
			set
			{
				if (index < 0 || index > 63)
					throw new ArgumentOutOfRangeException("Index must be in interval [0 - 63]");
				if (value < 0 || value > 1)
					throw new ArgumentException("Value must be only 0 or 1");

				// Clear the bit at position index
				this.Value &= ~(ulong)(1 << index);

				// Set the bit at position index to value
				this.Value |= value << index;

			}
		}


		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 63; i >= 0; i--)
				yield return (int)(this.Value >> i) & 1;
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			return this.Value.Equals((obj as BitArray64).Value);
		}

		public override int GetHashCode()
		{
			var hashCode = 0;
			foreach (var item in this)
			{
				hashCode += (hashCode ^ item.GetHashCode());
			}

			return hashCode;
		}
	}
}
