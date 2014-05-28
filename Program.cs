/* 
* Created by SharpDevelop. 
* User: Ivette 
* Date: 07/05/2014 
* Time: 03:41 p. m. 
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers. 
*/ 
using System; 
using MySql.Data.MySqlClient; 
namespace Practica6 
{ 
	class Program 
	{ 
		public static void Main(string[] args) 
	{ 
		int pal = 5; 
		do{ 
			Console.WriteLine(" 				Menú:  					\n\n\n"); 
			Console.WriteLine(" 				1. Ver 					"); 
			Console.WriteLine(" 				2. Agregar 				"); 
			Console.WriteLine(" 				3. Editar 				"); 
			Console.WriteLine(" 				4. Eliminar 			"); 
			Console.WriteLine(" 				5. Salir 				\n\n\n"); 
			Console.WriteLine(" 			SELECCIONE UNA OPCION 		"); 
			Profesores profe = new Profesores(); 
			
				switch (Console.Read())
					{ 
						case'1': 
						Console.WriteLine(" VER LISTA DE PROFESORES "); 
						profe.Mostrartodos(); 
						Console.WriteLine("\n \nPulse cualquier tecla para regresar al menú principal \n"); 
						Console.ReadKey(true); 
		
						break;
						case'2': 
						Console.WriteLine(" AGREGAR PROFESORES A LA LISTA \n \n"); 
						Console.WriteLine( "Ingresa el codigo del profesor :\n \n" ); 
						Console.ReadLine(); 
						string codigo = Console.ReadLine(); 
						Console.WriteLine( "Ingresa el nombre del profesor :\n \n" ); 
						string nombre = Console.ReadLine(); 
						profe.insertarRegistroNuevo(codigo, nombre); 
						break; 
						
						case'3': 
						Console.WriteLine( "EDITAR ELEMENTOS DE LA LISTA PROFESORES \n\n\n" ); 
						Console.WriteLine("Ingrese el codigo que deseea editar: \n\n"); 
						Console.ReadLine();
						string id = Console.ReadLine(); 
						if(profe.Buscarid(id)) 
							{ 
								Console.WriteLine("Codigo"); 
								Console.WriteLine("Nombre"); 
								Console.WriteLine("Seguro que desea continuar"); 
								string opc= Console.ReadLine(); 
								if(opc=="s") 
									{ 
										Console.WriteLine("Ingresa el código"); 
										codigo=Console.ReadLine(); 
										Console.WriteLine("Ingresa el nombre"); 
										nombre=Console.ReadLine(); 
										profe.editar(id, codigo, nombre); 
									} 
							} 
						else 
							{ 
								Console.WriteLine( "El id no existe " ); 
								Console.ReadLine(); 

							} 
						break; 
						
						case'4': 
						Console.WriteLine( "Dame el  ID del registro" );
						Console.ReadLine();
							 id = Console.ReadLine();
      						if(profe.Buscarid(id )){
							 	codigo = Console.ReadLine();
								nombre = Console.ReadLine();
								
								Console.WriteLine("¿Seguro que desea eliminarlo?" );
								string dig = Console.ReadLine();
								if(dig == "s")
									profe.eliminarRegistroPorId( id);
								}
							else{
								Console.WriteLine( "El id no existe presione cualquier tecla para continuar " );
      							 Console.ReadLine();
      							
							}
							 
      						break;
						
						case'5': 
						System.Console.Clear(); 
						break; 
					} 
					System.Console.Clear(); 
		  }
			while( pal < 5 ); 
	} 
	} 
}