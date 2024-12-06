using System;

using System;

namespace NotificacoesApp.Models
{
public class Notificacao
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty; // Valor padrão
    public string Gravidade { get; set; } = string.Empty; // Valor padrão
    public DateTime DataRecebimento { get; set; }
}
}
