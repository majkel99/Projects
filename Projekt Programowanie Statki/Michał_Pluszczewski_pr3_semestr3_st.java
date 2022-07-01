package statki;

public class Statki {
      
public static void main(String[] args) {
        char[][] plansza = new char[10][10];
        wypelnienie_planszy(plansza);
        int rozmiar = 4;
        int ilosc = 1;
        
        while (rozmiar != 0) {
            for (int i = 0; i < ilosc; i++)
                LosowaniePunktu(plansza, rozmiar);
            rozmiar--;
            if (rozmiar == 3)
                ilosc += 2;
            if (rozmiar == 1)
                ilosc++;
        }
        
         wypisanie_planszy(plansza);
    } 
public static void wypelnienie_planszy(char[][] plansza){
        for(int i=0 ; i < 10 ; i++ )
            for(int j=0 ; j < 10 ; j++ )
                plansza[i][j]='-';
    }

public static void wypisanie_planszy(char[][] plansza){
        for(int i=0 ; i < 10 ; i++ ){
            for(int j=0 ; j < 10 ; j++ ){
                System.out.print(plansza[i][j]+"  ");
            }
                System.out.println("");
        }
    }
public static int getRandomNumber(int min, int max) {
    return (int) ((Math.random() * (max - min)) + min);
}
public static void LosowaniePunktu(char[][] plansza, int rozmiar_m){
    int x, y, kierunek;
    while(true){
        while(true){
            x=getRandomNumber(0,9);
            y=getRandomNumber(0,9);
            kierunek=getRandomNumber(0,3);
            if (sprawdz_punkt(plansza,x,y,kierunek,rozmiar_m))
                break;          
        }
      //prawo
        if (kierunek == 0 && (x >= 0 && x <= 9) && (y >= 0 && y+rozmiar_m < 9)) {
            for (int i = 0; i < rozmiar_m; i++) {
                plansza[x][y + i] = 'x';
            }
            break;
        }
        //lewo
        else if (kierunek == 1 && (x >= 0 && x <= 9) && (y-rozmiar_m > 0 && y <= 9)) {
            for (int i = 0; i < rozmiar_m; i++) {
                plansza[x][y - i] = 'x';
            }
            break;
        }
        //gora
        else if (kierunek == 2 && (x-rozmiar_m > 0  && x <= 9) && (y >= 0 && y <= 9)) {
            for (int i = 0; i < rozmiar_m; i++) {
                plansza[x - i][y] = 'x';
            }
            break;
        }
        //dol
        else if (kierunek == 3 && (x >= 0 && x+rozmiar_m < 9) && (y >= 0 && y <= 9)) {
            for (int i = 0; i < rozmiar_m; i++) {
                plansza[x + i][y] = 'x';
            }
            break;
        }
    }
}
public static boolean sprawdz_punkt(char[][] plansza,int x, int y, int kierunek, int rozmiar_m){
    //sprawdzamy czy można wpisać masztowiec w punkcie dla kierunku prawo
    if(kierunek==0 && y >= 0 && y+rozmiar_m < 9){
        while(rozmiar_m!=0){
         if(x==0 & y==0){
            if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') ||(plansza[x + 1][y + rozmiar_m] != '-') || (plansza[x + 1][y + rozmiar_m-1] != '-') ){
                return false;
         }
         }
         else if(x==9 & y==0){
             if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') || (plansza[x - 1][y + rozmiar_m] != '-') || (plansza[x - 1][y + rozmiar_m-1] != '-')){
                return false;
             }
         }
         else if(x==0 && y!=0){
            if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') || (plansza[x + 1][y + rozmiar_m] != '-') || (plansza[x + 1][y + rozmiar_m-1] != '-') || (plansza[x][y - 1] != '-') || (plansza[x + 1][y - 1] != '-')){
                return false;
         }
         }
         else if(y==0 && x!=0 && x!=9){
            if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') || (plansza[x + 1][y + rozmiar_m] != '-') || (plansza[x + 1][y + rozmiar_m-1] != '-') || (plansza[x - 1][y + rozmiar_m] != '-') || (plansza[x - 1][y + rozmiar_m-1] != '-')){
                return false;
         }
         }
         else if(x==9 && y!=0){
             if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') || (plansza[x - 1][y + rozmiar_m] != '-') || (plansza[x - 1][y + rozmiar_m-1] != '-') || (plansza[x][y - 1] != '-') || (plansza[x - 1][y - 1] != '-')){
                return false;
             }
         }         
         else if (x!=9 && x!=0 && y!=0){
            if((plansza[x][y + rozmiar_m] != '-') || (plansza[x][y + rozmiar_m-1] != '-') | (plansza[x + 1][y + rozmiar_m] != '-') || (plansza[x + 1][y + rozmiar_m-1] != '-') || (plansza[x - 1][y + rozmiar_m] != '-') || (plansza[x - 1][y + rozmiar_m-1] != '-') || (plansza[x][y - 1] != '-') || (plansza[x + 1][y - 1] != '-') || (plansza[x - 1][y - 1] != '-')){
                return false;
         } 
         }

            rozmiar_m--;
        }   
        }
    //sprawdzamy czy można wpisać masztowiec w punkcie dla kierunku lewo
    if (kierunek == 1 && y-rozmiar_m > 0 && y <= 9) {
        while (rozmiar_m != 0) {
            if(x==0 && y==9){
            if((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m-1] != '-') || (plansza[x + 1][y - rozmiar_m] != '-') || (plansza[x + 1][y - rozmiar_m-1] != '-') ){
                return false;
         }
         }
         else if(x==9 && y==9){
             if((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m-1] != '-') || (plansza[x - 1][y - rozmiar_m] != '-') || (plansza[x - 1][y - rozmiar_m-1] != '-')){
                return false;
             }
         }
         else if(x==0 && y!=9){
            if((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m-1] != '-') || (plansza[x + 1][y - rozmiar_m] != '-') || (plansza[x + 1][y - rozmiar_m-1] != '-') || (plansza[x][y + 1] != '-') || (plansza[x + 1][y + 1] != '-')){
                return false;
         }
         }
         else if(y==9 && x!=0 && x!=9){
            if((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m-1] != '-') || (plansza[x + 1][y - rozmiar_m] != '-') || (plansza[x + 1][y - rozmiar_m-1] != '-') || (plansza[x - 1][y - rozmiar_m] != '-') || (plansza[x - 1][y - rozmiar_m-1] != '-')){
                return false;
         }
         }
         else if(x==9 && y!=9){
             if((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m-1] != '-') || (plansza[x - 1][y - rozmiar_m] != '-') || (plansza[x - 1][y - rozmiar_m-1] != '-') || (plansza[x][y + 1] != '-') || (plansza[x - 1][y + 1] != '-')){
                return false;
             }
         }  
         else if(x!=9 && x!=0 && y!=9){
             if ((plansza[x][y - rozmiar_m] != '-') || (plansza[x][y - rozmiar_m + 1] != '-') || (plansza[x + 1][y - rozmiar_m] != '-') || (plansza[x + 1][y - rozmiar_m + 1] != '-') || (plansza[x - 1][y - rozmiar_m] != '-') || (plansza[x - 1][y - rozmiar_m + 1] != '-') || (plansza[x][y + 1] != '-') || (plansza[x + 1][y + 1] != '-') || (plansza[x - 1][y + 1] != '-')){
                return false;
            }      
         }
            
            rozmiar_m--;
        }
    }
    //sprawdzamy czy można wpisać masztowiec w punkcie dla kierunku gora
    if (kierunek == 2 && x-rozmiar_m > 0 && x <= 9) {
        while (rozmiar_m != 0) {
         if(x==9 && y==0){
            if((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y + 1] != '-') || (plansza[x - rozmiar_m + 1][y + 1] != '-')){
                return false;
         }
         }
         else if(x==9 && y==9){
             if((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y - 1] != '-') || (plansza[x - rozmiar_m + 1][y - 1] != '-') ){
                return false;
             }
         }
         else if(y==0 && x!=9){
            if((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y + 1] != '-') || (plansza[x - rozmiar_m + 1][y + 1] != '-') || (plansza[x + 1][y] != '-') || (plansza[x + 1][y + 1] != '-')){
                return false;
         }
         }
         else if(y==9 && x!=9){
            if((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y - 1] != '-') || (plansza[x - rozmiar_m + 1][y - 1] != '-') || (plansza[x + 1][y] != '-') || (plansza[x + 1][y - 1] != '-')){
                return false;
         }
         }
         else if(x==9 && y!=9 && y!=0){
             if ((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y + 1] != '-') || (plansza[x - rozmiar_m + 1][y + 1] != '-') || (plansza[x - rozmiar_m][y - 1] != '-') || (plansza[x - rozmiar_m + 1][y - 1] != '-')){
                return false;
             }
         }
         else if(x!=9 && y!=0 && y!=9){
             if ((plansza[x - rozmiar_m][y] != '-') || (plansza[x - rozmiar_m + 1][y] != '-') || (plansza[x - rozmiar_m][y + 1] != '-') || (plansza[x - rozmiar_m + 1][y + 1] != '-') || (plansza[x - rozmiar_m][y - 1] != '-') || (plansza[x - rozmiar_m + 1][y - 1] != '-') || (plansza[x + 1][y] != '-') || (plansza[x + 1][y + 1] != '-') || (plansza[x + 1][y - 1] != '-'))
                return false;
         }   
            rozmiar_m--;
        }
    }
    //sprawdzamy czy można wpisać masztowiec w punkcie dla kierunku dol
    if (kierunek == 3 && x >= 0 && x+rozmiar_m < 9) {
        while (rozmiar_m != 0) {
         if(x==0 & y==0){
            if((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y + 1] != '-') || (plansza[x + rozmiar_m - 1][y + 1] != '-') ){
                return false;
         }
         }
         else if(x==0 & y==9){
             if((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y - 1] != '-') || (plansza[x + rozmiar_m - 1][y - 1] != '-') ){
                return false;
             }
         }
         else if(y==0 && x!=0){
            if((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y + 1] != '-') || (plansza[x + rozmiar_m - 1][y + 1] != '-')  || (plansza[x - 1][y] != '-') || (plansza[x - 1][y + 1] != '-')  ){
                return false;
         }
         }
         else if(y==9 && x!=0){
            if((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y - 1] != '-') || (plansza[x + rozmiar_m - 1][y - 1] != '-') || (plansza[x - 1][y] != '-') || (plansza[x - 1][y - 1] != '-')){
                return false;
         }
         }
         else if(x==0 && y!=0 && y!=9){
             if ((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y + 1] != '-') || (plansza[x + rozmiar_m - 1][y + 1] != '-') || (plansza[x + rozmiar_m][y - 1] != '-') || (plansza[x + rozmiar_m - 1][y - 1] != '-') ){
                return false;
             }
         }
         else if(x!=0 && y!=0 && y!=9){
             if ((plansza[x + rozmiar_m][y] != '-') || (plansza[x + rozmiar_m - 1][y] != '-') || (plansza[x + rozmiar_m][y + 1] != '-') || (plansza[x + rozmiar_m - 1][y + 1] != '-') || (plansza[x + rozmiar_m][y - 1] != '-') || (plansza[x + rozmiar_m - 1][y - 1] != '-') || (plansza[x - 1][y] != '-') || (plansza[x - 1][y + 1] != '-') || (plansza[x - 1][y - 1] != '-')){
                return false;
            }
         }           
            rozmiar_m--;
        }
    }
    
    return true;       
}
}