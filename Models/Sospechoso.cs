class Sospechoso{
    public string nombreSospechoso {get;private set;}
    public string foto {get;private set;}

    public Sospechoso (){
        nombreSospechoso = "";
        foto ="";
    }

    public void generarSospechoso(string NombreSospechoso,string Foto){
        nombreSospechoso=NombreSospechoso;
        foto=Foto;
    }
}