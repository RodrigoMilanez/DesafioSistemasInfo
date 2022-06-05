namespace DesafioSistemasInfo.Models
{
    
    public class Usuario
    {
        public Usuario()
        {
        }
        public int id { get; set; }
        public string nome { get; set; }
        
        public string apelido { get; set; }
        public string senha { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
    }
}
