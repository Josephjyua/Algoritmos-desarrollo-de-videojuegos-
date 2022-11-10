using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn{

    class Program
    {
        static void Main(string[] args)
        { 
            Random r = new Random();
            int x = r.Next(70,100);
            int y = r.Next(70,100);
            int maxRooms = r.Next(30,40);
            int c = 0;
            
            Dungeon dungeon = new Dungeon();
            dungeon.Generar(x,y,maxRooms);
            for(int i = 0; i < dungeon.dungeon.GetUpperBound(0); i++){
                for(int j = 0; j < dungeon.dungeon.GetUpperBound(1); j++){
                    if(dungeon.dungeon[i,j].active){
                        c++;
                        Console.WriteLine($"Sala {i},{j}:");
                        Console.WriteLine($"Norte: {dungeon.dungeon[i,j].n}");
                        Console.WriteLine($"Sur: {dungeon.dungeon[i,j].s}");
                        Console.WriteLine($"Este: {dungeon.dungeon[i,j].e}");
                        Console.WriteLine($"Oeste: {dungeon.dungeon[i,j].o}");
                        Console.WriteLine("--------");
                        
                        
                    }
                }
            }
            
           Console.WriteLine($"Total de salas: {c}");  
        }
    }
    
    public class Dungeon{
    
        public Nodo[,] dungeon = new Nodo[100,100];
        public Wallker w = new Wallker(1,1);
             
        
        public void Generar(int maxX,int maxY,int maxRooms){
            dungeon = new Nodo[maxX,maxY];
            
            for(int i = 0; i < maxX; i++){
                for(int j = 0; j < maxY; j++){
                    dungeon[i,j] = new Nodo();
                }
            }
                            
            w = new Wallker(maxX,maxY);
            int mr = maxRooms;
            
                
            while(mr > 0){
                                                   
                if(
                !dungeon[w.posActual.x,w.posActual.y].active){
                  dungeon[w.posActual.x,w.posActual.y].active = true;
                    
                    mr--;                  
               }//endif

               // 1 left
               // 2 right   
               // 3 up
               // 4 down
               
               // comparar en X
               if(w.dir == 1){
                   
                   dungeon[w.posActual.x, w.posActual.y].e = true;
                   
               }
               
               if(w.dir == 2){
                   
                   dungeon[w.posActual.x, w.posActual.y].o = true;
                
               }
               
               // comparar en Y          
               if(w.dir == 3){
                   
                   dungeon[w.posActual.x, w.posActual.y].s = true;
                
               }
               
               if(w.dir == 4){
                   
                   dungeon[w.posActual.x, w.posActual.y].n = true;
                   
               }
               
               if(dungeon[w.posActual.x,w.posActual.y].n){
                   dungeon[w.posActual.x,w.posActual.y+1].s = true;        
               }
               
               if(dungeon[w.posActual.x,w.posActual.y].s){
                   dungeon[w.posActual.x,w.posActual.y-1].n = true;        
               }
               
               if(dungeon[w.posActual.x,w.posActual.y].e){
                   dungeon[w.posActual.x+1,w.posActual.y].o = true;        
               }
               
               if(dungeon[w.posActual.x,w.posActual.y].o){
                   dungeon[w.posActual.x-1,w.posActual.y].e = true;        
               }
                                               
               w.Mov(); 
                        
            }
                                 
    }
    
    public class Nodo{
        public bool n = false;
        public bool s = false;
        public bool e = false;
        public bool o = false;
        
        public bool active = false;
             
    }
    
    public class Wallker{
        Random r = new Random();
        public int x = 0;
        public int y = 0;    
        
        public int dir = 0; 
        // 1 left
        // 2 right   
        // 3 up
        // 4 down
        public Vector2Int posActual = new Vector2Int(0,0);
        
        public void Mov(){
            
            int n = r.Next(0,2);
            if( n > 0 ){
            // Mover en x
                int movX = r.Next(0,2);
                if(movX > 0 ){
                    if( posActual.x < x - 5){
                                      
                        posActual.x ++;
                        dir = 2;                   
                        
                    } 
                }
                else{
                    if( posActual.x > 0 + 5){
                        
                        posActual.x --;
                        dir = 1;
                    }
                }
            }
            else{
                // mover en y
                int movY = r.Next(0,2);
                if(movY > 0 ){
                    if( posActual.y < y - 5 ){
                        
                        posActual.y ++;
                        dir = 3;
                    } 
                }
                else{
                    if( posActual.y > 0 + 5 ){
                         
                        posActual.y --;
                        dir = 4;
                    }
                }
            }  
            
        }
        
        public Wallker(int a, int l){
        
            // inicializar en una posicion aleatoria 
            posActual.x = r.Next(0,a);
            posActual.y = r.Next(0,l);
            
            x = a;
            y = l;
             
        }  
    }
    
    public class Vector2Int{
    
        public int x;
        public int y;
    
        public Vector2Int(int _x, int _y){
        
            x = _x;
            y = _y;
        
        }
    }        
}
}
