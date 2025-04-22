using static System.Environment;

namespace RegAsistencia.EntityModels;

public class RegAsistenciaContextLogger
{
  public static void WriteLine(string message)
  {
    string path = Path.Combine(GetFolderPath(
      SpecialFolder.DesktopDirectory), "regasistencialog.txt");

    StreamWriter textFile = File.AppendText(path);
    textFile.WriteLine(message);
    textFile.Close();
  }
}