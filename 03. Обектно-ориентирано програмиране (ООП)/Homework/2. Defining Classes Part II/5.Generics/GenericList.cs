using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
	public class GenericList<T> where T : IComparable
	{
		//Constant Fields
		private const int DefaultCapacity = 1;

		//Fields
		private T[] elements;

		//Constructors
		public GenericList(int capacity = DefaultCapacity)
		{
			this.Count = 0;
			this.Capacity = capacity;

			this.elements = new T[this.Capacity];
		}

		//Properies
		public int Count { get; private set; }
		public int Capacity { get; private set; }

		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= this.Count)
					throw new ArgumentOutOfRangeException("Index is out of range");
				return this.elements[index];
			}
			set { this.elements[index] = value; }
		}

		//Methods
		public void Add(T element)
		{
			this.Count++;
			this.Resize();
			this.elements[this.Count - 1] = element;
		}
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
				throw new ArgumentOutOfRangeException("Index is out of range");
			this.Count--;
			this.Resize();

			Array.Copy(this.elements, index + 1, this.elements, index, this.Count - index);

			this.elements[this.Count] = default(T);
		}
		public void InsertAt( int index,T element)
		{
			if (index < 0 || index > this.Count)
				throw new ArgumentOutOfRangeException("Index is out of range");
			this.Count++;
			this.Resize();

			Array.Copy(this.elements, index, this.elements, index + 1, this.Count - index - 1);
			this.elements[index] = element;
		}
		public void Clear()
		{
			this.Count = 0;
			this.Capacity = DefaultCapacity;
			this.elements = new T[this.Capacity];
		}
		public int IndexOf(T element)
		{
			return Array.IndexOf(this.elements, element);
		}
		public T Min()
		{
			return this.MinMax(false);
		}

		public T Max()
		{
			return this.MinMax(true);
		}

		private T MinMax(bool value)
		{
			T best = this.elements[0];

			for (int i = 1; i < this.Count; i++)
				if (value ? (best < (dynamic)this.elements[i]) : (best > (dynamic)this.elements[i]))
					best = this.elements[i];

			return best;
		}

		// Override 
		   public override string ToString()
        {
            if (this.Count == 0)
                return "Empty list!";

            StringBuilder result = new StringBuilder();
            result.Append("Element(s): ");

            for (int i = 0; i < this.Count; i++)
            {
                result.AppendFormat("{0}", this.elements[i].ToString());
               
                if (i + 1 < this.Count) 
                    result.Append(", ");
            }

            return result.ToString();
        }

		//Private Method
		private void Resize()
		{
			if (this.Count > this.Capacity)
			{
				this.Capacity *= 2;
				Array.Resize<T>(ref this.elements, this.Capacity);
			}
			//todo smaller itself
		}
	}
}
