#include <iostream.h>
using namespace std ;
int main ()
{
int n, br=0;
cout << "Vuvedi N 4isloto we!"<<endl;
cin>>n;
while(n)
{
        if((n%10)%2==0) 
        {
                     br++;
                        
                        }
        n/=10;
        }
cout<<br<<endl;
system("PAUSE");
return 0 ;
}