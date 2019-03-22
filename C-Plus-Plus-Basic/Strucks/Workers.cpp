#include<iostream>
#include<string>
using namespace std;
struct Hospital
{
   char name[31];
   char diagnose[31];
   int days;
};
int main()
{
    int n;
    cin>>n;
    Hospital workers[21];
    for(int i=0;i<n;i++)
    {
            cin.get();
            cin.getline(workers[i].name,31);
            cin>>workers[i].diagnose;
            cin>>workers[i].days;
    }
    char p[31];
    cin>>p;
    for(int j=0;j<n;j++)
    {
            if(strncmp(workers[j].diagnose,p)=0)
            {
                                  cout<<workers[j].name;
            }
    }
    system("PASUE");
    return 0;
    }