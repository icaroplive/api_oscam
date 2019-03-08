using System;
using webapi.Entities;
using webapi.Models;
using System.Linq;

namespace webapi.Services
{
    public class LacamentoMensal
    {
        private BancoContext db;
        public LacamentoMensal(BancoContext db)
        {
            this.db = db;
        }
        public bool lancar()
        {
            //pega todos os clientes ativos de todas as contas
            var cli = (from c in db.Cliente
                       join r in db.Revendedor on c.idUser equals r.idUser
                       where c.ativo == true
                       select new ClienteRevendedorViewModel() { Cliente = c, Revendedor = r }).ToList();
            //faz um loop para saber se ja existe cobrança para o mês atual
            foreach (var c in cli)
            {
                var dataVencimento = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.Month, c.Revendedor.diaVencimento));
                var fi = (from f in db.Financeiro
                          where f.idCliente == c.Cliente.id &&
                          f.dataVencimento == dataVencimento
                          select f
                ).FirstOrDefault();
                //se nao houver registro, insere no banco de dados
                if (fi == null)
                {
                    Financeiro fin = new Financeiro()
                    {
                        idCliente = c.Cliente.id,
                        idUser = c.Cliente.idUser,
                        valorCobrado = c.Cliente.valorCobrado,
                        valorLogin = c.Revendedor.valorLogin,
                        dataLancamento = DateTime.Now,
                        dataVencimento = dataVencimento
                    };
                    db.Financeiro.Add(fin);
                    db.SaveChanges();
                }

            }
            return true;
        }
    }
}