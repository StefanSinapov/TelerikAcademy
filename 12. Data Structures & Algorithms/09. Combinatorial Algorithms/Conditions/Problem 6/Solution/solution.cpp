#include <iostream>
using namespace std;

long long CalculateBinom(int n, int k)
{
    long long nominator = 1;
    for (int i = n; i >= (n - k + 1); i--)
    {
        nominator *= i;
    }

    long long denominator = 1;
    for (int i = k; i >= 1; i--)
    {
        denominator *= i;
    }

    return (nominator / denominator);
}

long CalculateSum(int numbers[], int n)
{
    long long sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += numbers[i];
    }
    return sum;
}

long long SolveSumSubSeq(int n, int k, int numbers[])
{
    long long sumSubSeq = CalculateBinom(n - 1, k) * CalculateSum(numbers, n);
    return sumSubSeq;
}

void ReadInputAndSolve()
{
    int tests, n, k;
	cin>>tests;

    for (int i = 0; i < tests; i++)
    {
		cin>>n;
		cin>>k;
		int numbers[1000];
		for (int i = 0; i < n; i++)
		{
			cin>>numbers[i];
		}

        cout<<SolveSumSubSeq(n, k, numbers)<<endl;
    }
}

int main()
{
	ReadInputAndSolve();
	return 0;
}