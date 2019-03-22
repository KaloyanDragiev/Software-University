#include<iostream>
using namespace std;
int main()
{
    int n,m,a[40][20],sum=0;
    cin>>n>>m;
    for(int i=0;i<n;i++)
     for(int j=0;j<m;j++)
            {
                         cout<<"a["<<i<<"]["<<j<<"]=";
                         cin>>a[i][j];
                         }
     for(int i=0;i<n;i++)
      for(int j=0;j<m;j++)
      {
              cout<<a[i][j]<<endl;
              sum+=a[i][j];
              }
              cout<<sum;
      
    system("PAUSE");
    return 0;
    }
