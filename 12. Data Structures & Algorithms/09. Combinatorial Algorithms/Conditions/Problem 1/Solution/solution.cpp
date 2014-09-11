#include <iostream>
using namespace std;
int main()
{
    string passwordTemplate;
    cin >> passwordTemplate;
    int unknownDigitsNumber = 0;
    for(int i = 0; i < passwordTemplate.length(); i++)
    {
        if (passwordTemplate[i] == '*')
        {
            unknownDigitsNumber++;
        }
    }
    long long answer = 1;
    for(int i = 1; i <= unknownDigitsNumber; i++)
    {
        answer *= 2;
    }
    cout << answer << endl;
    return 0;
}
