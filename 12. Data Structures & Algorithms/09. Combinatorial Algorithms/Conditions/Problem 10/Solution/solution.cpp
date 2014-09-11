#include <iostream>
using namespace std;

int AbsoluteValue(int number)
{
    return number < 0 ? -number : number;
}

int main()
{
    int n;
    cin >> n;

    unsigned long long * distances = new unsigned long long [n];

    for(int i=0; i<n; i++)
    {
        int obeliskX, obeliskY;
        cin >> obeliskX >> obeliskY;

        distances[i] = AbsoluteValue(obeliskX) + AbsoluteValue(obeliskY);
    }

    unsigned long long mask = 1;
    unsigned long long numSingleDistanceRepeats = mask << (n-1ULL);

    unsigned long long totalSum = 0;
    for(int i=0; i<n; i++)
    {
        totalSum += (distances[i] * numSingleDistanceRepeats);
    }

    cout<<totalSum<<endl;

    return 0;
}
