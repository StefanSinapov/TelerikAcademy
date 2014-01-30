/*	����� ��������� (��������� �� ������)


	���������� ��-���� ������� ������������
	���������� ���������� �� ������ quicksort.


	� ����� C++ ���������� � ���������� �������
	qsort (����������� � stdlib.h), ����� �� 
	����� �� �� ������ �� ������� �����:

	���������� ������� ������� �� ���������� 
	�� ��� ��������:

	int intcmp( const void * a, const void * b )
	{
		int A = *((int *) a), B = *((int *) b);

		if ( A < B ) return -1;
		if ( A > B ) return 1;

		return 0;
	}

	�������� �� qsort():
		- ������ �� ������
		- ���� ��������, �������� �� ���� ������� (� �������)
		- ���������� ������� (����������)

	qsort( a, n, sizeof(int), intcmp );
*/

#include <iostream.h>

// �� ���������� �� �������� ����� � rand()
#include <stdlib.h>
#include <time.h>

#define MAX_N 100

int a[MAX_N];
int n;

void quicksort( int a[], int left, int right )
{
	int x, t;
	int i, j;

	// ���� ����� �� �� ������� -> �����
	if ( left >= right ) return;

	// ������ ��������
	// (������� ����� ������� � ������� ������)
	x = a[(left + right)/2];

	// � �������� ������� � ������� ������ �� ������
	i = left; j = right;

	do
	{
		while ( a[i] < x ) ++i;
		while ( a[j] > x ) --j;

		// �������� ��� ������ �������� a[i] >= x >= a[j].
		// ��������� �� �� �� �� ������ � ����������� ������
		if ( i <= j )
		{
			t = a[i];
			a[i] = a[j];
			a[j] = t;
			++i; --j;
		}
	} while ( i <= j );
	
	// ��������� �� ������� ������
	if ( j > left ) quicksort( a, left, j );

	// ��������� �� ������� ������
	if ( i < right ) quicksort( a, i, right );
}

int main( void )
{
	int i;

	// �������������� �� ���������� �� �������� �����
	srand( time( NULL ) );

	// ���������� �� n ����� �[i], 0 <= a[i] <= 999.
	n = 20;
	for ( i = 0; i < n; i++ )
		a[i] = rand() % 1000;

	// ����� �� ������
	cout << n << " random numbers:";
	for ( i = 0; i < n; i++ )
		cout << ' ' << a[i];
	cout << endl;

	// ��������� � ������������ ���������.
	// ������ �� �������� � ��������� �� qsort(),
	// ����� � ������� ��-����.
	quicksort( a, 0, n - 1 );

	// ����� �� ������
	cout << "sorted:";
	for ( i = 0; i < n; i++ )
		cout << ' ' << a[i];
	cout << endl;

	return 0;
}