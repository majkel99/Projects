#include <iostream>
#include <conio.h>
#include <windows.h>
#include <stdio.h>     
#include <stdlib.h>     
#include <time.h>
#include<fstream>
#include "Nagłówek.h"
using namespace std;

int main()
{
    koniecGry = false;
    kierunek = STOP;
    x = szerokosc / 2;
    y = dlugosc / 2;
    srand(time(NULL));
    owocX = rand() % szerokosc;
    owocY = rand() % dlugosc;
    owocx= rand() % szerokosc;
    owocy= rand() % dlugosc;
    wynik = 0;
    //wywołanie funkcji menu
    menu();
    
    
    
    system("pause");
    return 0;
}


