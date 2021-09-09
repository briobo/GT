using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Persistencia
{
    public class BackupRestore : TopPersistencia
    {
        private static string workingDirectory = Environment.CurrentDirectory;
        private static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        private static string backupDirectory = projectDirectory + "\\BackupsDeBase";
        private static string xmlDirectory = projectDirectory + "/XMLFiles";
        private static string baseDataName = xmlDirectory + "/baseDeDatosXML-DATOS.xml";
        private static string baseSchemaName = xmlDirectory + "/baseDeDatosXML-SCHEMA.xsd";
        private static string baseControlFileName = xmlDirectory + "/baseDeDatosXML-CONTROL-FILE.xml";
        private static string baseBackupInfoFileName = xmlDirectory + "/baseDeDatosXML-BACKUPINFO-FILE.xml";

        private string fileName;
        private FolderBrowserDialog folderBrowserDialog1;

        public void hacerRestore()
        {

            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = backupDirectory;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Seleccione el archivo desde donde hacer RESTAURACION";
            openFileDialog1.DefaultExt = "zip";
            openFileDialog1.Filter = "curcuma backup files|backup-curcuma-*.zip";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string backup = openFileDialog1.FileName;
                DialogResult dialogResult = MessageBox.Show("Va a realizar un restore, esto borrara TODA la informacion actual, ¿Esta seguro?", "ATENCION!! LA RESTAURACION BORRARA TODOS LOS DATOS ACTUALES", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    hacerRestoreDesde(backup);
                    MessageBox.Show("El restore se realizo con exito, debe volver a ingresar al sistema");
                    Process.GetCurrentProcess().Kill();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Restore cancelado!!!");
                }


            }
            else
            {
                MessageBox.Show("Restore cancelado!!!");
            }

        }

        private void hacerRestoreDesde(string backup)
        {
            if (File.Exists(BackupRestore.baseDataName)) File.Delete(BackupRestore.baseDataName);
            if (File.Exists(BackupRestore.baseSchemaName)) File.Delete(BackupRestore.baseSchemaName);
            if (File.Exists(BackupRestore.baseControlFileName)) File.Delete(BackupRestore.baseControlFileName);
            if (File.Exists(BackupRestore.baseBackupInfoFileName)) File.Delete(BackupRestore.baseBackupInfoFileName);

            using (ZipFile zip = ZipFile.Read(backup))
            {
                zip.Password = "mypassword";
                zip.ExtractAll(xmlDirectory);
            }
        }

        public void hacerBackup()
        {

            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = BackupRestore.backupDirectory;
            folderBrowserDialog1.Description = "Seleccione el directorio donde guardar el backup";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                guardarBackupEn(path);
                MessageBox.Show("El backup se realizo con exito");
            }
            else
            {
                MessageBox.Show("Backup cancelado!!!");
            }


        }

        public void guardarBackupAutomaticamente()
        {
            if (!Directory.Exists(backupDirectory)) return;

            string date = DateTime.Now.ToString("yyyyMMddHHmmss");

            fileName = "backup-curcuma-automatico-" + date + ".zip";
            guardarBackupEnPathConNombreArchivo(backupDirectory, fileName);
            depurarDirectorioDeBackups();
        }

        private void depurarDirectorioDeBackups()
        {
            var sortedFiles = new DirectoryInfo(backupDirectory).GetFiles("backup-curcuma-automatico-*.zip")
                                                  .OrderByDescending(f => f.LastWriteTime.Year <= 1601 ? f.CreationTime : f.LastWriteTime)
                                                  .ToList();
            int backupsADejar = 20;
            int contador = 1;
            foreach (var item in sortedFiles)
            {
                if (contador > backupsADejar)
                    File.Delete(item.FullName);
                contador++;
            }

        }

        private void guardarBackupEn(string path)
        {
            string date = DateTime.Now.ToString("yyyyMMddHHmmss");

            fileName = "backup-curcuma-manual-" + date + ".zip";
            guardarBackupEnPathConNombreArchivo(path, fileName);
        }

        private void guardarBackupEnPathConNombreArchivo(string path, string archivo)
        {
            crearArchivoDeInfoBase();
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "mypassword";
                zip.AddFile(BackupRestore.baseDataName, "");
                zip.AddFile(BackupRestore.baseSchemaName, "");
                zip.AddFile(BackupRestore.baseControlFileName, "");
                zip.AddFile(BackupRestore.baseBackupInfoFileName, "");
                zip.Save(path + "\\" + archivo);
            }
        }

        private void crearArchivoDeInfoBase()
        {
            XmlWriter writer = XmlWriter.Create(BackupRestore.baseBackupInfoFileName);
            writer.WriteStartElement("Backup");
            writer.WriteElementString("Fecha", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
        }

    }
}

