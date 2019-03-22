#include<iostream>

using namespace std ;
int main ()
{
int chislo, max;
  cin>>chislo;
  max=chislo;
  while(chislo!=0)
  {
                  if(max<chislo) 
                  {
                  max=chislo;
                  if(max%2!=0)
                  {
                              cout<<chislo;
                              }
                  else 
                  {
                       cout<<"NE!";
                  }
                  }
               
                  
                  cin>>chislo;
                  }
system("PAUSE");
return 0 ;
}
