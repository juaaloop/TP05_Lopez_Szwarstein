public class Sospechoso
{
    public string nombreSospechoso { get; private set; }
    public string foto { get; private set; }
    public Sospechoso()
    {
        this.nombreSospechoso = "";
        this.foto = "";
    }
      public void crearSospechoso(string nombreSospechoso, string foto)
    {
        this.nombreSospechoso = nombreSospechoso;
        this.foto = foto;
    }
}