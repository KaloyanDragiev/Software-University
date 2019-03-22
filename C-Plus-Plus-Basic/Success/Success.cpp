#include <iostream>
 
using namespace std;
 
struct Student
{
    int number;
    char name[20];
    int result;
};
 
void addStudent(Student *st)
{
    cout << "Nomer: ";
    cin >> st->number;
 
    cout << "Ime: ";
    cin >> st->name;
 
    cout << "Uspeh:";
    cin >> st->result;
}
 
void displayStudent(Student st)
{
    cout << st.number << " " << st.name << " " << st.result << "\n";
}
 
int main()
{
    Student students[20];
    int bestStrudentId = 0;
 
    int n;
    cout<<"Vyvedete broq na studentite: ";
    cin>>n;
 
    for(int i=0; i<n && i<20; i++)
    {
        addStudent(&students[i]);
        if(students[bestStrudentId].result < students[i].result)
            bestStrudentId = i;
    }
 
    cout << "Studenta s nai dobyr uspeh e: ";
    displayStudent(students[bestStrudentId]);
    system("pause");
    return 0;
}