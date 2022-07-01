#pragma once
#include <iostream>
#include <conio.h>
#include <windows.h>
#include <stdio.h>     
#include <stdlib.h>     
#include <time.h>
#include<fstream>
using namespace std;
enum Kierunek { STOP = 0, LEWO, PRAWO, GORA, DOL };
Kierunek kierunek;
bool koniecGry;
int szerokosc = 20;
int dlugosc = 20;
int x, y, owocX, owocY, wynik, ogon_weza, opcja;
int owocx, owocy;
int pop_x, pop_y, pop_x2, pop_y2, ogon_x[20], ogon_y[20];
int a=30;
//funkcja wypisujaca plansze do gry
void WypisaniePlanszy() {
    system("cls");
    //rysowanie planszy
    for (int i = 0; i < szerokosc + 2; i++) {
        cout << "-";
    }
    cout << endl;
    for (int i = 0; i < szerokosc; i++) {
        for (int j = 0; j < dlugosc; j++) {
            if (j == 0)
                cout << "|";
            //rysowanie wê¿a
            if (i == y && j == x)
                cout << "S";
            //rysowanie owoców
            else if (i == owocY && j == owocX)
                cout << "O";
            else if (i == owocy && j == owocx)
                cout << "O";
            else {
                bool wypisz = false;
                //rysowanie ogona
                for (int n = 0; n < ogon_weza; n++) {
                    if (ogon_x[n] == j && ogon_y[n] == i) {
                        cout << "o";
                        wypisz = true;
                    }
                }
                if (wypisz == false)
                    cout << " ";
            }


            if (j == dlugosc - 1)
                cout << "|";
        }
        cout << endl;
    }
    for (int i = 0; i < szerokosc + 2; i++) {
        cout << "-";
    }
    cout << endl;
    cout << "Wynik:" << wynik << endl;
}
//funkcja odpowiedzialna za przypisanie klawiszy
void PrzypisanieKlawiszy() {
    //funkcja sprawdzaj¹ca czy w buforze klawiatury s¹ dane do odczytania
    if (_kbhit()) {
        //funkcja oczekuj¹ca na znak ,pozwalaj¹ca na odczytanie jego kodu
        switch (_getch()) {
            //lewo
        case 'a':
            kierunek = LEWO;
            break;
            //prawo
        case 'd':
            kierunek = PRAWO;
            break;
            //gora
        case 'w':
            kierunek = GORA;
            break;
            //dol
        case 's':
            kierunek = DOL;
            break;
        }
    }
}
//funkcja odpowiedzialna za poruszanie sie po planszy
void PoruszaniePoPlanszy() {

    if (kierunek == LEWO)
        x--;
    if (kierunek == PRAWO)
        x++;
    if (kierunek == GORA)
        y--;
    if (kierunek == DOL)
        y++;

    //Sprawdzamy czy nie wychodzimy poza plansze
    if (x >= szerokosc || x < 0 || y >= dlugosc || y < 0) {
        koniecGry = true;
        cout << "Koniec gry! Przegrales!" << endl;
    }
    //sprawdzamy czy nie natrafiliœmy na w³asny ogon
    for (int i = 0; i < ogon_weza; i++) {
        if (ogon_x[i] == x && ogon_y[i] == y)
            koniecGry = true;
    }
    //jeœli natrafimy na owoc to dodajemy wynik, zwiekszamy ogon wê¿a oraz losujemy pozycje kolejnego owoca
    if (x == owocx && y == owocy) {
        wynik += 50;
        srand(time(NULL));
        owocx = rand() % szerokosc;
        owocy = rand() % dlugosc;
        ogon_weza++;
        //zmniejszaj¹c a zwiêkszamy szybkoœæ wê¿a, jeœli natrafimy na owoc
        if (a > 0)
            a--;
     }
    //jeœli natrafimy na owoc to dodajemy wynik, zwiekszamy ogon wê¿a oraz losujemy pozycje kolejnego owoca
    if (x == owocX && y == owocY) {
        wynik+=50;
        srand(time(NULL));
        owocX = rand() % szerokosc;
        owocY = rand() % dlugosc;
        ogon_weza++;
        //zmniejszaj¹c a zwiêkszamy szybkoœæ wê¿a, jeœli natrafimy na owoc
        if (a > 0)
            a--;
    }
}
//funkcja wypisuj¹ca ogon wê¿a
void Ogon() {
    pop_x = ogon_x[0];
    pop_y = ogon_y[0];
    //dziêki temu zapisowi ogon pojawi siê za nami, a nie w innym miejscu
    ogon_x[0] = x;
    ogon_y[0] = y;
    //pêtla w której sprawiamy ¿e kolejne czêœæi ogona pojawiaj¹ siê za nami i za nami pod¹¿aj¹
    for(int i = 1; i < ogon_weza; i++) {
        pop_x2 = ogon_x[i];
        pop_y2 = ogon_y[i];
        ogon_x[i] = pop_x;
        ogon_y[i] = pop_y;
        pop_x = pop_x2;
        pop_y = pop_y2;
    }
}
void gra();
void menu();
void zasadyGry();
//funkcja odczytujaca zapisy wyników z gry i pokazujaca je na ekranie
void tablicaWynikow() {
    system("cls");
    cout << "tablica wynikow:" << endl;
    ifstream odczyt("wyniki.txt");
    if (odczyt.is_open())
    {
        char wiersz[100];
        while (odczyt.getline(wiersz, 100)) //dopóki jest co czytaæ z pliku
        {
            cout << wiersz << endl; //wypisywanie z pliku
        }
    }
    else
        cout << "Nie udalo sie otworzyc pliku";

    cin.get();
    cout << "---------------------" << endl;
    cout << "1 Menu glowne" << endl;
    cout << "2 Zasady gry" << endl;
    cout << "3 Gra" << endl;
    cout << "4 Wyjscie" << endl;
    cin >> opcja;
    cout << endl;
    switch (opcja)
    {
    case 1:
        menu();
        break;
    case 2:
        zasadyGry();
        break;
    case 3:
        gra();
        break;
    case 4:
        koniecGry = true;
        break;
    default:
        cout << "Prosze podac prawidlowy wybor" << endl;
        break;
    }
}
//funkcja opisujaca zasady gry
void zasadyGry() {
    system("cls");
    cout << "---------------------" << endl;
    cout << "W grze gracz kontroluje dlugie i cienkie stworzenie, podobne do weza, ktore porusza sie po obramowanej planszy" << endl;
    cout << "zbierajac jedzenie, probujac nie uderzyc glowa w sciane lub o wlasna czesc ciala. " << endl;
    cout << "Kiedy waz zje owoc, jego ogon staje sie coraz dluzszy oraz porusza sie szybciej co utrudnia gre." << endl;
    cout << "Gracz porusza sie za pomoca klawiszy w,a,s,d(gora, lewo, dol, prawo).Gracz nie moze zatrzymac weza, gdy gra jest w toku." << endl;
    cout << "---------------------" << endl;
    cout << "1 Menu glowne" << endl;
    cout << "2 Tablica wynikow" << endl;
    cout << "3 Gra" << endl;
    cout << "4 Wyjscie" << endl;
    cin >> opcja;
    cout << endl;
    switch (opcja)
    {
    case 1:
        menu();
        break;
    case 2:
        tablicaWynikow();
        break;
    case 3:
        gra();
        break;
    case 4:
        koniecGry = true;
        break;
    default:
        cout << "Prosze podac prawidlowy wybor" << endl;
        break;
    }
}
//funkcja menu gry
void menu()
{
        system("cls");
        cout << "---------------------" << endl;
        cout << "1 Gra" << endl;
        cout << "2 Tablica wynikow" << endl;
        cout << "3 Zasady gry" << endl;
        cout << "4 Wyjscie" << endl;
        cin >> opcja;
        cout << endl;
        switch (opcja)
        {
        case 1:
            gra();
            break;
        case 2:
            tablicaWynikow();
            break;
        case 3: 
            zasadyGry();
            break;
        case 4:
            koniecGry = true;
            break;
        default:
            cout << "Prosze podac prawidlowy wybor" << endl;
            break;
        }   
}
//funkcja zapisujaca dane do pliku
void zapisz()
{
    fstream plik;
    plik.open("wyniki.txt", ios::out | ios::app);
    plik << wynik<<endl;
    plik.close();
}
//funkcja w ktorej gramy az nie nastapi koniec gry, po czym wywo³ujemy funkcje zapisz
void gra()
{
        system("cls");
        while (koniecGry != true) {
            WypisaniePlanszy();
            PrzypisanieKlawiszy();
            Ogon();
            PoruszaniePoPlanszy();
            Sleep(a);
        }
        if (koniecGry == true)
            zapisz();
}
