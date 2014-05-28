/*
 * Created by SharpDevelop.
 * User: Ivette
 * Date: 12/05/2014
 * Time: 04:42 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;


namespace Practica6
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL()
		{
			
		}
		
		protected void abrirConexion()
		{
			string connectionString = 
			"Server=127.0.0.1;" +
			"Database=escuela;" +
			"User ID=root;" +
			"Password=erick3;" +
			"Pooling=false;";

			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open();
		}
		
		
		protected void cerrarConexion()
		{
			this.myConnection.Close();
			this.myConnection = null;
		}
	}
}
