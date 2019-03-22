#include<iostream>
#include<string>
using namespace std;
struct Firma
{
   char name[31];
   char egn[11];
   char duty[21];
   double payment;
};
int main()
{
    int n;
    cin>>n;
    Firma workers [21];
    for(int i=0;i<n;i++)
    {
            cin.get();
            cin.getline(workers[i].name,31);
            cin>>workers[i].egn;
            cin>>workers[i].duty;
            cin>>workers[i].payment;
    }
    for(int j=0;j<n;j++)
    {
            if(workers[j].payment<700)
            {
                                  cout<<workers[j].name;
            }
    }
    system("PASUE");
    return 0;
    }