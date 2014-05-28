/*
 * Created by SharpDevelop.
 * User: Ivette
 * Date: 12/05/2014
 * Time: 04:43 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;

namespace Practica6
{
	/// <summary>
	/// Description of Profesores.
	/// </summary>
	public class Profesores : MySQL
	{
		public Profesores()
		{
			
		}
		
		public void Mostrartodos()
		{
			this.abrirConexion();
			MySqlCommand mycommand = new MySqlCommand(this.querySelect(),myConnection);
			MySqlDataReader myReader = mycommand.ExecuteReader();
			
			while (myReader.Read())
			{
				string id = myReader["id"].ToString();
				string codigo = myReader["codigo"].ToString();
				string nombre = myReader["nombre"].ToString();
				Console.WriteLine("ID: " + id + " Código: " + codigo + " Nombre: " + nombre);
			}
			
			myReader.Close();
			myReader=null;
			mycommand.Dispose();
			mycommand=null;
			this.cerrarConexion();
		}
		
		public void insertarRegistroNuevo(string codigo, string nombre){
			this.abrirConexion();
			string sql = "INSERT INTO `profesor` (`codigo`, `nombre`) VALUES ('" + codigo + "', '" + nombre + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void editar(string id, string codigo, string nombre){
			this.abrirConexion();
			string sql = "UPDATE `profesor` SET `codigo`='" + codigo + "', `nombre`='" + nombre + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		public void editarCodigoRegistro(string id, string codigo){
			this.abrirConexion();
			string sql = "UPDATE `profesor` SET `codigo`='" + codigo + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void editarNombreRegistro(string id, string nombre){
			this.abrirConexion();
			string sql = "UPDATE `profesor` SET `nombre`='" + nombre + "' WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}

		public void eliminarRegistroPorId(string id){
			this.abrirConexion();
			string sql = "DELETE FROM `profesor` WHERE (`id`='" + id + "')";
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
				"FROM profesor";
		}
		private string queryBuscar( string id ){
			return "SELECT * "  +
			"FROM Profesor where id = '"+id+"' ";
		}
		public bool Buscarid( string id ){
			this.abrirConexion();
           		 MySqlCommand myCommand = new MySqlCommand(this.queryBuscar( id ),myConnection);
           		 MySqlDataReader myReader = myCommand.ExecuteReader();	
			bool retorno = myReader.HasRows;

        		myReader.Close();
        		myReader = null;
       	 		myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return retorno;
		}
		
	}
}
