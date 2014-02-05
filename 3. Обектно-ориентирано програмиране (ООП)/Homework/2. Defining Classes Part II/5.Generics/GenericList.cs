using System;
using System.Collections.Generic;

namespace Generics
{
	public class GenericList<T> where T:IComparable
	{
		//Constant Fields
		private const int DefaultCapacity = 1;

		//Fields
		private T[] elements;

		//Constructors
		public GenericList(int capacity=DefaultCapacity)
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
			this.elements[this.Count-1] = element;
		}
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.Count)
				throw new ArgumentOutOfRangeException("Index is out of range");
			this.Count--;
			this.Resize();

			Array.Copy(this.elements, index + 1, this.elements, index, this.Count - index);

			//this.elements[this.Count] = default(T); ??
		}

		//Private Method
		private void Resize()
		{
			if(this.Count>this.Capacity)
			{
				this.Capacity *= 2;
				Array.Resize<T>(ref this.elements ,this.Capacity);
			}
			//todo smaller itself
		}
	}
}
