using System.Windows.Forms;

static class Program
{
    [System.STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Lonesure.Form1());
    }
}
