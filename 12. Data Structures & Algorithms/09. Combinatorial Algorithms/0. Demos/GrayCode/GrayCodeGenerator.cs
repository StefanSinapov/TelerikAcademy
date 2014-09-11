using System;

class GrayCodeGenerator
{
	const int n = 4;
	static int[] arr = new int[n];

	static void Main()
	{
		ForwardGray(n-1);
	}

	static void ForwardGray(int k)
	{
		if (k < 0)
		{
			Print();
			return;
		}
		arr[k] = 0;
		ForwardGray(k - 1);
		arr[k] = 1;
		BackwardGray(k - 1);
	}
	
	static void BackwardGray(int k)
	{  
		if (k < 0) 
		{ 
			Print(); 
			return; 
		}
		arr[k] = 1;  
		ForwardGray(k - 1);
		arr[k] = 0;  
		BackwardGray(k - 1);
	}
	
	static void Print()
	{
		Console.WriteLine(String.Join(", ", arr));
	}
}
