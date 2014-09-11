#include <algorithm>
#include <iostream>
#include <vector>
using namespace std;
#define FORC(it,v) for( __typeof((v).begin()) it = (v).begin(); it != (v).end(); ++it )
const int inf = 2147483647;
int factors(int num)
{
    int count = 0;
    for(int i = 1; i <= num; ++i)
    {
        if (num%i == 0) count++;
    }
    return count;
}
int main()
{
    vector <int> V;
    int n = 0;
    // Input
    cin >> n;
    for(int i = 0; i < n; i++)
    {
        int c;
        cin >> c;
        V.push_back(c);
    }
    // Solve
    int mini = inf;
    int sol = 0;
    sort( V.begin(), V.end() );
    do
    {
        int x = 0;
        FORC( it, V ) x = x*10 + *it;
        int tmp = factors(x);
        if(tmp < mini)
        {
            mini = tmp;
            sol = x;
        }
    } while(next_permutation(V.begin(), V.end()));
    // Output
    cout << sol << endl;
    return 0;
}
