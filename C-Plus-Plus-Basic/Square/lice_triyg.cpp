#include <iostream>
#include <fstream>
#include <cmath>
using namespace std;
struct point
{
    int x,y;
};
int ccw(point p0, point p1, point p2)
{ int dx1=p1.x-p0.x;
  int dy1=p1.y-p0.y;
  int dx2=p2.x-p0.x;
  int dy2=p2.y-p0.y;
  return dx1*dy2-dy1*dx2;
}
bool ccwb(point p0, point p1, point p2)
{ int dx1=p1.x-p0.x;
  int dy1=p1.y-p0.y;
  int dx2=p2.x-p0.x;
  int dy2=p2.y-p0.y;
  return dx1*dy2<dy1*dx2;
}
int main()
{point a,b,c;

    cin>>a.x>>a.y;
    cin>>b.x>>b.y;
    cin>>c.x>>c.y;
    cout<<"Liceto na triygylnika e: "<<fabs(ccw(a,b,c))/2<<endl;
    if(ccwb(a,b,c)) cout<<"Polojitelna orientaciq!\n";
    else cout<<"Otricatelna orientaciq!\n";
}

