#include <iostream> 
#include<cstdlib>
using namespace std; 
int main() 
{ 
int sum, s, u , m, k , suma , max;
cin>>sum;
    s=sum%10;
    u=sum/10%10;
    m=sum/100%10;
    k=sum/1000;
    suma = s+u+m+k;
    cout<<suma;
    max = s;
    if(max<u)
system("PAUSE");
return 0; 
}