public interface IAuditoriaService
{
    void Registrar(string usuario, string acao, string entidade);
    List<LogAuditoria> Listar();
}