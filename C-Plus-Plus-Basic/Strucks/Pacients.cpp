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
   char buf[2];
   Hospital pacients[50];
   cin>>n;
   for(int i=0;i<n;i++)
   {
    cin.get();
        cin.getline(pacients[i].name,31);
    cin>>pacients[i].diagnose;
    cin>>pacients[i].days;
   }
   int ind=0,max=pacients[0].days;
   char FindDiagnose[31];
   cin>>FindDiagnose;
   for(int j=0;j<n;j++)
   {
    if(strncmp(pacients[j].diagnose,FindDiagnose)==0)
       {
           cout<<pacients[j].name<<endl;
        }
        if(max<pacients[j].days)
       {
      max=pacients[j].days;
      ind=j;
        }
   }
   cout<<pacients[ind].name<<" ";
   cout<<pacients[ind].diagnose<<" ";
   cout<<pacients[ind].days<<endl;
   system("PAUSE");
   return 0;
}