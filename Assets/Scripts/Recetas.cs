using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recetas : MonoBehaviour
{
    public List<string> ingredientes = new List<string>();
    public List<Receta> libroRecetas = new List<Receta>();

    public struct Receta
    {

        public int[] ingres;
        public string nombre;
        public float tiempo;
        public int precio;
        public GameObject prefab;

        public Receta(string name, float segs, int[] ings, int prcio,GameObject pref)
        {
            ingres = ings;
            tiempo = segs;
            nombre = name;
            precio = prcio;
            prefab = pref;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        LlenarIngredientes();

        //Construir RECETA y añadir a la lista
        int[] auxIngs = { 14, 19, 3, 7 };
        Receta aux = new Receta("Tagliatelle Bolognesa", 5, auxIngs,19, Resources.Load<GameObject>("Tagliatelle Bolognesa"));//Index 0
        libroRecetas.Add(aux);

        //Añadir aqui
        int[] auxIngs2 = { 0, 1, 2, 3 };
        aux = new Receta("Carbonara", 6, auxIngs2,20, Resources.Load<GameObject>("Carbonara"));//Index 1
        libroRecetas.Add(aux);

        int[] auxIngs3 = { 4, 15, 16, 11 };
        aux = new Receta("Pizza Prosciutto e Funghi", 7, auxIngs3,17, Resources.Load<GameObject>("Pizza Prosciutto e Funghi"));//index 2
        libroRecetas.Add(aux);

        int[] auxIngs4 = { 17, 16, 18, 7, 5 };
        aux = new Receta("Ensalada piamontesa", 8, auxIngs4,20, Resources.Load<GameObject>("Ensalada piamontesa"));//index 3
        libroRecetas.Add(aux);

        int[] auxIngs5 = { 20, 21, 22, 23 };
        aux = new Receta("Gelato", 10, auxIngs5,15, Resources.Load<GameObject>("Gelato"));//index 4
        libroRecetas.Add(aux);

        int[] auxIngs6 = { 7, 9, 24 };
        aux = new Receta("Pasta e ceci", 12, auxIngs6,20, Resources.Load<GameObject>("Pasta e ceci"));//index 5
        libroRecetas.Add(aux);

        int[] auxIngs7 = { 25, 2, 0, 26 };
        aux = new Receta("Arancini", 15, auxIngs7,22, Resources.Load<GameObject>("Arancini"));//index 6
        libroRecetas.Add(aux);

        int[] auxIngs8 = { 4, 15, 7, 2, 27 };
        aux = new Receta("Pizza Napolitana", 18, auxIngs8,27, Resources.Load<GameObject>("Pizza Napolitana"));//index 7
        libroRecetas.Add(aux);

        int[] auxIngs9 = { 2, 13, 28 };
        aux = new Receta("Tiramisú", 20, auxIngs9,18, Resources.Load<GameObject>("Tiramisú"));//index 8
        libroRecetas.Add(aux);

        int[] auxIngs10 = { 4, 15, 8, 2, 12 };
        aux = new Receta("Pizza al Padellino", 24, auxIngs10,29, Resources.Load<GameObject>("Pizza al Padellino"));//index 9
        libroRecetas.Add(aux);

        int[] auxIngs11 = { 4, 15, 12, 29 };
        aux = new Receta("Focaccia", 28, auxIngs11,26, Resources.Load<GameObject>("Focaccia"));//index 10
        libroRecetas.Add(aux);

        int[] auxIngs12 = { 7, 6, 10, 4 };
        aux = new Receta("Caponata Siciliana", 30, auxIngs12,20, Resources.Load<GameObject>("Caponata Siciliana"));//index 11
        libroRecetas.Add(aux);
    }
    public void LlenarIngredientes()
    {
        ingredientes.Add("Huevo");//0
        ingredientes.Add("Gunciale");//1
        ingredientes.Add("Queso");//2
        ingredientes.Add("Espaguetis");//3
        ingredientes.Add("Harina");//4
        ingredientes.Add("Berenjena");//5
        ingredientes.Add("Pimientos");//6
        ingredientes.Add("Tomate");//7
        ingredientes.Add("Calabaza");//8
        ingredientes.Add("Garbanzos");//9
        ingredientes.Add("Anchoas");//10 
        ingredientes.Add("Champiñones");//11
        ingredientes.Add("Hierbas");//12
        ingredientes.Add("Queso Crema");//13 
        ingredientes.Add("Carne Picada");//14
        ingredientes.Add("Aceite de Oliva");//15
        ingredientes.Add("Jamón");//16
        ingredientes.Add("Patata");//17
        ingredientes.Add("Mostaza");//18
        ingredientes.Add("Cebolla");//19
        ingredientes.Add("Leche");//20
        ingredientes.Add("Vainilla");//21
        ingredientes.Add("Azúcar");//22
        ingredientes.Add("Chocolate");//23
        ingredientes.Add("Pasta corta");//24
        ingredientes.Add("Arroz");//25
        ingredientes.Add("Pan rallado");//26
        ingredientes.Add("Albahaca");//27
        ingredientes.Add("Bizcocho Soletilla");//28
        ingredientes.Add("Aceitunas");//29

    }
}
