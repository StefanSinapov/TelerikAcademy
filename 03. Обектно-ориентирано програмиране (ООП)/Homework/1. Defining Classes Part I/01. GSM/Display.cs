using System;
class Display
{
	//constats 
	private const int maxSize = 12;

	//Fields
	private int size;
	private int numberOfColors;

	//Constructors
	public Display()
		: this(0, 0)
	{

	}
	public Display(int size)
		: this(size, 0)
	{

	}
	public Display(int size, int numberOfColors)
	{
		this.size = size;
		this.numberOfColors = numberOfColors;
	}

	//Properties
	public int Size
	{
		get { return this.size; }
		set
		{
			if (value < 0 && value > maxSize)
				throw new ArgumentOutOfRangeException("Display size cannot be negativ or larger than 12");
			this.size = value;
		}
	}
	public int NumberOfColors
	{
		get { return this.numberOfColors; }
		set
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException("Number of display colors cannot be negativ");
			this.numberOfColors = value;
		}
	}
}
