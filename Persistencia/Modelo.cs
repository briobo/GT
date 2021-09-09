using CapaDeSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Persistencia
{
    public class Modelo : TopPersistencia
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        private static string xmlDirectory = projectDirectory + "/XMLFiles";
        private static string baseDataName = xmlDirectory + "/baseDeDatosXML-DATOS.xml";
        private static string baseSchemaName = xmlDirectory + "/baseDeDatosXML-SCHEMA.xsd";
        private static string baseControlFileName = xmlDirectory + "/baseDeDatosXML-CONTROL-FILE.xml";
        private DataSet modelo;
        private static Modelo instance;

        public Modelo()
        {
            modelo = prepararModelo();
        }

        public void rollback()
        {
            modelo.RejectChanges();
        }


        public DataSet prepararModelo()
        {
            if (existeModeloGuardado(baseSchemaName))
                return obtenerModeloGuardado();
            else
                return inicializarNuevoModelo();
        }

        public DataTable obtenerTabla(string tabla)
        {
            return modelo.Tables[tabla];
        }


        private DataSet inicializarNuevoModelo()
        {
            DataSet nuevoModelo = new DataSet("Gesto de Talentos");
            agregarTablas(nuevoModelo);
            desencriptarModelo(nuevoModelo);
            nuevoModelo.AcceptChanges();
            persistirModelo(nuevoModelo, baseSchemaName, baseDataName);

            return nuevoModelo;
        }

        public void persistirModelo()
        {
            persistirModelo(modelo, baseSchemaName, baseDataName);
        }
        
        private void persistirModelo(DataSet modelo, String modelPath, String dataPath)
        {
            verificarConsistenciaDeModelo();
            modelo.AcceptChanges();

            DataSet modeloEncriptado = encriptarModelo(modelo);
            modeloEncriptado.WriteXml(dataPath, XmlWriteMode.DiffGram);
            modeloEncriptado.WriteXmlSchema(modelPath);
            crearArchivoDeControl();
            BackupRestore backup = new BackupRestore();
            backup.guardarBackupAutomaticamente();
        }
        
        private DataSet encriptarModelo(DataSet modelo)
        {
            DataSet modeloEncriptado = modelo.Copy();

            foreach (DataTable table in modeloEncriptado.Tables)
            {
                SeguridadDeDatos.encriptarTabla(table);
            }

            modeloEncriptado.AcceptChanges();
            return modeloEncriptado;
        }
        
        private void crearArchivoDeControl()
        {
            byte[] hashArchivoDatos = AdministradorDeSeguridadDeInformacion.ComputeHash(baseDataName);
            byte[] hashArchivoEstructura = AdministradorDeSeguridadDeInformacion.ComputeHash(baseSchemaName);
            crearArchivoDeControlConHash(hashArchivoDatos, hashArchivoEstructura);
        }
        
        private void crearArchivoDeControlConHash(byte[] hashArchivoDatos, byte[] hashArchivoEstructura)
        {
            string datos = Convert.ToBase64String(hashArchivoDatos);
            string estructura = Convert.ToBase64String(hashArchivoEstructura);
            string hashDatos = AdministradorDeSeguridadDeInformacion.encriptar(datos);
            string hashEstructura = AdministradorDeSeguridadDeInformacion.encriptar(estructura);

            XmlWriter writer = XmlWriter.Create(baseControlFileName);
            writer.WriteStartElement("Control");
            writer.WriteElementString("ArchivoDatos", hashDatos);
            writer.WriteElementString("ArchivoEstructura", hashEstructura);
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }

        private static void agregarTablas(DataSet nuevoModelo)
        {
            IEnumerable<Type> clases = ModeloTablas.Tabla.clases();
            foreach (Type clase in clases.ToList())
            {
                dynamic obj = Activator.CreateInstance(clase);
                DataTable tablaNueva = obj.obtenerTabla();
                nuevoModelo.Tables.Add(tablaNueva);
                obj.insertarValoresPorDefecto(tablaNueva);
            }
        }
        
        private DataSet obtenerModeloGuardado()
        {
            verificarConsistenciaDeModelo();
            DataSet modelo = new DataSet("Gestor de Talentos");
            modelo.ReadXmlSchema(baseSchemaName);
            modelo.ReadXml(baseDataName);

            desencriptarModelo(modelo);

            return modelo;
        }
        
        private void desencriptarModelo(DataSet modelo)
        {
            foreach (DataTable table in modelo.Tables)
            {
                SeguridadDeDatos.desencriptarTabla(table);
            }
        }
        
        private void verificarConsistenciaDeModelo()
        {
            try
            {
                if (!File.Exists(baseDataName) && !File.Exists(baseSchemaName) && !File.Exists(baseControlFileName))
                    return;

                XmlDocument controlFile = new XmlDocument();
                controlFile.Load(baseControlFileName);
                string hashDataFile = controlFile.DocumentElement.SelectSingleNode("/Control/ArchivoDatos").InnerText;
                string hashStructureFile = controlFile.DocumentElement.SelectSingleNode("/Control/ArchivoEstructura").InnerText;

                byte[] hashData = AdministradorDeSeguridadDeInformacion.ComputeHash(baseDataName);
                byte[] hashStructure = AdministradorDeSeguridadDeInformacion.ComputeHash(baseSchemaName);

                string datos = Convert.ToBase64String(hashData);
                string estructura = Convert.ToBase64String(hashStructure);

                bool datosConsistentes = AdministradorDeSeguridadDeInformacion.verificar(datos, hashDataFile);
                bool estructuraConsistente = AdministradorDeSeguridadDeInformacion.verificar(estructura, hashStructureFile);

                if (!datosConsistentes || !estructuraConsistente)
                {
                    restaurarBase();
                }

            }
            catch (Exception)
            {
                restaurarBase();
            }
        }
        
        private void restaurarBase()
        {
            DialogResult dialogResult = MessageBox.Show("La base de datos fue corrompida, ¿Desea hacer un restore?", "BASE DE DATOS CORRUPTA", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                BackupRestore restore = new BackupRestore();
                restore.hacerRestore();
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                MessageBox.Show("La base de datos fue corrompida, necesita una restauracion, saliendo...");
                Process.GetCurrentProcess().Kill();
            }
        }

        private bool existeModeloGuardado(string path)
        {

            if (!File.Exists(path)) return false;

            return true;
        }

        public static Modelo getInstance()
        {
            if (instance == null)
            {
                instance = new Modelo();
            }

            return instance;

        }


    }
}
