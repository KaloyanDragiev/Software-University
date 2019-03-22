#include<iostream>
using namespace std ;
int main ()
{
    int n,a[10],b[10];
    cin>>n;
    for(int i =0;i<n;i++)
    {
            cin>>a[i];
            }
    for(int i =0;i<n;i++)
    {
            b[i]=a[n-i-1];
            cout<<b[i]<<" ";
            }
    system("PAUSE");
    return 0;
    }