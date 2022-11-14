using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.GraphModel;


public class cCosimundo
{
	float[,] grafo = new float[24, 24];
	public cCosimundo()
	{
		string text = System.IO.File.ReadAllText("nodos.txt");
		System.Console.WriteLine("Contenido del archivo = {0}", text);
	}
}
