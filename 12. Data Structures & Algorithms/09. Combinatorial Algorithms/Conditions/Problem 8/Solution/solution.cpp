#include <iostream>
#include <string>
using namespace std;

#define MAX_PASCAL_COLS 1000
#define FIRST_VAR_POSITION 1
#define SECOND_VAR_POSITION 3

long long * lastPascalTriangleRow = new long long[MAX_PASCAL_COLS];
long long * currentPascalTriangleRow = new long long[MAX_PASCAL_COLS];

int main()
{
    for(int col = 0; col < MAX_PASCAL_COLS; col++)
    {
        lastPascalTriangleRow[col] = 0;
        currentPascalTriangleRow[col] = 0;
    }

    string expressionString;
    cin>>expressionString;

    char firstVar = expressionString[FIRST_VAR_POSITION];
    char secondVar = expressionString[SECOND_VAR_POSITION];

    int power;
    cin>>power;

    lastPascalTriangleRow[0] = 1;

    for(int row = 0; row < power; row++)
    {
        bool reachedLastRowEnd = false;
        currentPascalTriangleRow[0] = 1;
        int col = 1;
        while(!reachedLastRowEnd)
        {
            currentPascalTriangleRow[col] = lastPascalTriangleRow[col-1] + lastPascalTriangleRow[col];
            if(lastPascalTriangleRow[col] == 0)
            {
                reachedLastRowEnd = true;
            }
            col++;
        }

        int lastMeaningColumn = col;

        for(int col=0; col<lastMeaningColumn; col++)
        {
            lastPascalTriangleRow[col] = currentPascalTriangleRow[col];
        }
    }

    cout <<"("<<firstVar<<"^"<<power<<")";
    int col = 1;
    while(currentPascalTriangleRow[col]!=0)
    {
        if(power-col==0)
        {
            cout<<"+("<<secondVar<<"^"<<col<<")";
        }
        else
        {
            cout<<"+"<<currentPascalTriangleRow[col]<<"("<<firstVar<<"^"<<power-col<<")"<<"("<<secondVar<<"^"<<col<<")";
        }
        col++;
    }
    cout<<endl;

    return 0;
}
