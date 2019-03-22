#include<iostream.h>
#include<cstdlib>
using namespace std ;
int main ()
{
    int max , min ,chislo;
    cin>>chislo;
    min=chislo;
    max=chislo;
    while(chislo!=0)
    {
                    if(max<chislo)max=chislo;
                    if(min>chislo)min=chislo;
                    cin>>chislo;
                    }  
                    cout<<min<<endl;
                    cout<<max<<endl;  
    
    system("PAUSE");
    return 0 ;
    }