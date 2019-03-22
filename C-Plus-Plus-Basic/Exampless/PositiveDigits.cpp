#include <iostream> 
using namespace std; 
int main() 
{ 
    int n , br=0;
    cin>>n;

while(n)
{
 if((n%10)%2==0)br++;
 n=n/10;
}                 
cout<<br<<endl;
system("PAUSE");
return 0; 
}