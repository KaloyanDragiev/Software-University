#include <iostream>
using namespace std;

int max(int max1, int max2)
{
    int result;
    if(max1 > max2)
    {
        result = max1;
    }
    else
    {
        result = max2;
    }
    return result;
}

void print (int number)
{
    cout << number <<endl;
}

int main()
{
    int a ;
    int b ;
    cin >> a >> b;
    int result = max(a, b);
    print(result);
    system ("PAUSE");
    return 0;
}
